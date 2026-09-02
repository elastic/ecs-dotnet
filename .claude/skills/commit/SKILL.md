---
name: commit
description: Stage relevant files and create a well-formed git commit. Use this when the user asks to commit changes, save work, or create a commit.
---

# Commit Skill

Read [`.claude/skills/writing-style.md`](../writing-style.md) before writing the commit message.

Creates a clean, well-formed commit following this project's conventions.

## Steps

### 1. Check for project hooks

If the repo has a hook runner, ensure it is installed before committing. Common patterns:

```bash
# Husky.Net (dotnet)
if [ -f .husky/task-runner.json ] && [ ! -f .husky/_/husky.sh ]; then
  dotnet tool restore && dotnet husky install
fi

# Husky (Node)
# hooks install automatically via npm ci / npm install

# lefthook
if [ -f lefthook.yml ] || [ -f .lefthook.yml ]; then
  lefthook install
fi
```

Do not use `--no-verify`.

### 2. Understand what changed

```bash
git status
git diff
git diff --staged
git log --oneline -5
```

### 3. Stage files

Stage specific files by name — never `git add -A` or `git add .` blindly. Exclude:
- `.env` files or anything with secrets/credentials
- Large binaries not already tracked
- Unrelated changes to the task at hand

### 4. Write the commit message

- **First line**: Imperative mood, ≤72 chars, no trailing period. Front-load the outcome — a reader scanning `git log` sees this line only.
- **Body** (optional): One short paragraph explaining *why*, not what. Skip if the title is self-explanatory. Follow the sentence mechanics in `writing-style.md`.
- **Trailer**: Add a `Co-Authored-By:` line that identifies the model that helped write this commit. Use whatever attribution feels accurate — the model name you know yourself to be running as, or simply `Claude` if you are uncertain. The address is always `noreply@anthropic.com`. The point is honest attribution, not a precise version string.

Always pass the message via HEREDOC to avoid shell escaping issues:

```bash
git commit -m "$(cat <<'EOF'
Title here

Optional body explaining why.

Co-Authored-By: Claude <noreply@anthropic.com>
EOF
)"
```

### 5. Handle hook failures

If a git hook fails:
1. Read the error output carefully
2. Fix the underlying issue (formatting, linting, type errors — whatever the hook checks)
3. Re-stage the affected files
4. Create a **new commit** — never `git commit --amend` for a failed commit, and never use `--no-verify`

### 6. Verify success

```bash
git status
```

Confirm a clean working tree.

### 7. Refresh the PR description if one exists

```bash
gh pr view --json number,url,isDraft,baseRefName --jq '{number,url,isDraft,baseRefName}' 2>/dev/null
```

- **No PR** → done. Say nothing.
- **PR exists** → compare the current body against the current diff versus the PR's base branch. A PR description always describes the current diff against the base branch. It is never a log of the commits on the branch and never records the direction the work took. If any section (`## What`, `## Verify`, or the lead paragraph) no longer describes that diff, the description is stale.
- **Stale description** → read and follow [pr](../pr/SKILL.md)'s update path (step 7). Do not hand-edit the body inline from the commit skill. State plainly what was refreshed.
- **Still accurate** → state that the description is still accurate. No edit needed.
