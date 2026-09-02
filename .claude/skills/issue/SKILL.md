---
name: issue
description: File a well-formed bug report or feature request. Use when the user asks to open an issue, report a bug, or request a feature.
---

# Issue Skill

Read [`.claude/skills/writing-style.md`](../writing-style.md) before writing anything.

Files a GitHub issue that matches the repo's templates, applies correct labels, and checks for duplicates first.

## Steps

### 1. Check for duplicates

Search for near-duplicates before opening anything. Link any you find in the issue body rather than filing a second. Use the full URL form for all links — see `## Linking to issues and pull requests` in [`writing-style.md`](../writing-style.md).

```bash
gh issue list --search "<key terms>" --limit 10
```

### 2. Determine the issue type

- **Bug** — something that used to work stopped, or produces wrong output. Use `bug-report` structure.
- **Feature / enhancement** — something that does not exist yet, or needs to be better. Use `enhancement` structure.

### 3. Write the title

- ≤70 characters, no trailing period
- States the observable problem or the wanted capability — not the internal cause or the implementation

### 4. Write the body

**Bug report:**

```
<One sentence: what went wrong and, briefly, under what condition. Be specific.>

### What happened

<What you saw. Include the command you ran, the input, and the exact output or
 error. Commands and error messages go in fenced blocks.>

### How to reproduce

<Minimal steps. A command and the file it ran against is enough if that covers it.
 Skip this section if the "What happened" section already makes it reproducible.>

### Version or commit

<Output of the tool's `--version` flag, or the commit SHA if building from source.
 This is the single most useful piece of triage data.>
```

**Feature request:**

```
<One sentence: the outcome you want, not the implementation.>

### What is getting in your way

<The concrete limitation. What are you trying to do, and what stops you?
 One to three sentences.>

### What would you like instead

<Your proposed change or outcome. If you have a specific implementation in mind,
 describe it — but a clear outcome is enough.>

### Anything else

<Examples from other tools, links, screenshots, or context that did not fit above.
 Skip this section if there is nothing to add.>
```

Formatting rules:
- Same plain-language rules as PR bodies — active voice, short sentences, no mechanical noun clusters.
- Commands and error messages in fenced blocks.
- Backticks on all identifiers: flags, config keys, file paths, method names.
- Skip any section that has nothing to say — a blank section adds noise, not structure.

### 5. Choose labels

Apply the labels this repo defines. Common defaults:

1. **Type** (required): `bug` or `enhancement`
2. **Area** (one, if the repo defines area labels): pick the label that matches the affected subsystem
3. **`needs triage`** (if the repo uses it)

Do not invent new labels. Check `.github/` or the repo's CONTRIBUTING guide for the label set.

### 6. Create the issue

One call — title, labels, and body together:

```bash
gh issue create \
  --title "<title>" \
  --label "bug,needs triage" \
  --body "$(cat <<'EOF'
<lead sentence>

### What happened

...

### Version or commit

...
EOF
)"
```

Replace `bug` with `enhancement` for feature requests. Omit area or triage labels if the repo does not use them.

### 7. Return the issue URL

Always print the URL so the user can open it directly.
