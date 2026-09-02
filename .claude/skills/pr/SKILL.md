---
name: pr
description: Create a GitHub pull request with a focused why/what body. Use when the user asks to open a PR, create a pull request, or ship a branch.
---

# PR Skill

Read [`.claude/skills/writing-style.md`](../writing-style.md) before writing anything.

Creates a GitHub PR body that a newcomer can orient from in under a minute: front-loaded outcome, grounded Why, behaviour-led What, verifiable by the reviewer.

## Steps

### 1. Understand the branch

```bash
git status
git log main..HEAD --oneline
git diff main...HEAD --stat
```

### 2. Commit uncommitted work if needed

If the working tree has changes that belong in this PR, read and follow [commit](../commit/SKILL.md) first. Do not commit inline. Do not skip hooks.

### 3. Push (if needed)

```bash
git push -u origin HEAD
```

### 4. Write the PR title

- ≤70 characters, imperative mood, no trailing period
- States what changed at a human level — not a file list, not a symbol name
- No `[bug]` / `[feature]` / `[chore]` prefixes — the label carries the type

### 5. Write the PR body

Required structure:

```
<One or two sentences, no heading. What this changes and the effect.
 A newcomer reads only this and knows whether the PR concerns them.>

**Prompt summary:** <One paragraph, two to three sentences. What the author was asked
 to do in their own framing — the goal behind the branch, not the diff. Present tense,
 active voice. This is the ask; ## Why is the problem in the code. They are not
 interchangeable and neither restates the other. Omit only when the branch has no
 originating ask.>

## Why
<Two to four sentences. The concrete failure or gap. Active voice, present tense
 for current behaviour. Do not open with the history of a prior PR.>

## What

#### <Conceptual label — not a filename>
<Prose paragraph. Group by what changed conceptually, not by which files moved.
 Lead with behaviour. Name a symbol only when the reviewer needs it to find the code.
 Two to four sentences. Three to five sections total.>

## Verify
<How a reviewer confirms this locally. Use real commands they would run.
 If there is no clear local verification step, omit this section entirely.
 Do not list CI checks or scripts an agent would run to prove their own work —
 those are not reviewer steps.>
```

Conditional add-ons — each is one or two sentences with a bold lead-in, no heading:

- **Breaking** — what a consumer must change and when it bites them.
- **Out of scope** — a gap this PR deliberately leaves, so a reviewer does not raise it as a finding.
- **Risk** — shared or production state this touches. Required when the change reaches infrastructure, credentials, or shared data stores.
- **Stack** — position and links when this is one of several stacked PRs: `3 of 5, on top of [#42](https://github.com/org/repo/pull/42)`. A bare `Stack: 3/5` with no links is not enough.

**Do not** include bullet lists of changed files. Do not summarize what the diff already states plainly.

### 6. Apply labels

Apply the labels this repo uses. Common defaults:

| Label | Use when |
|---|---|
| `bug` | A defect in existing behaviour is fixed |
| `enhancement` or `feature` | A capability is added or improved |
| `chore` | Cleanup, refactor, internal restructure — no user-visible change |
| `documentation` | Docs-only change |
| `dependencies` | Dependency version bumps |

Check `.github/workflows/` or the repo's CONTRIBUTING guide for any enforced label policy before creating the PR.

### 7. Check whether a PR already exists

```bash
gh pr view --json number,url,baseRefName --jq '{number,url,baseRefName}' 2>/dev/null
```

**If a PR exists — update it.**

Rebuild the body from the cumulative diff against the PR's own base branch (not a hardcoded `main`):

```bash
git diff origin/<baseRefName>...HEAD --stat
git diff origin/<baseRefName>...HEAD
```

Write the description of **the current diff against the base** — never a log of the commits on the branch and never an "update" or "addendum" appended to the old body. Any section of the old body that no longer matches the diff is wrong, not history. Replace it.

- Preserve the original `**Prompt summary:**` verbatim unless the ask itself changed; extend it rather than replace it when scope was added.
- Reassess the label — added commits can shift a `chore` to a `bug`.
- Apply in one call:

```bash
gh pr edit --title "<title>" --body "$(cat <<'EOF'
<new body>
EOF
)"
```

Add or remove the label only if it changed:

```bash
gh pr edit --add-label "<new-label>" --remove-label "<old-label>"
```

**If no PR exists — create it.** Proceed to step 8.

### 8. Create the PR

One call — title, label, and body together. No follow-up `gh pr edit`:

```bash
gh pr create --title "<title>" --label "<label>" --body "$(cat <<'EOF'
<lead sentence(s)>

**Prompt summary:** ...

## Why

...

## What

#### ...

...

## Verify

```bash
<command>
```
EOF
)"
```

### 9. Return the PR URL

Always print the URL so the user can open it directly.
