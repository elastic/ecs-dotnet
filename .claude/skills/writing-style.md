# Writing style for commits, PRs, and issues

Every commit message, PR body, and issue filed in this repo follows these rules.
Skills that write those artifacts read this file first.

---

## Governing principles (ISO 24495-1)

- **Relevant** — write for a reviewer who has not seen the branch. Cut whatever the diff already states plainly.
- **Findable** — the first sentence states the outcome. A newcomer reads it and knows whether the change concerns them.
- **Understandable** — plain words, short sentences, no assumed context.
- **Usable** — after reading, the reviewer can evaluate, revert, or reproduce.

---

## Sentence mechanics (ASD-STE100, adapted)

*The ASD-STE100 sentence rules apply here. Its ~900-word approved vocabulary does not — it rejects `assembler`, `idempotent`, and `reconciliation` and its clipped imperative register produces mechanical prose. Take the mechanics, drop the dictionary.*

- Active voice. Name the actor. "A retry clears the lock", not "The lock is cleared on retry".
- One idea per sentence. Around 25 words maximum.
- Six sentences maximum per paragraph.
- Present tense for how the code behaves now; past tense only for what it used to do.
- No noun cluster longer than three words. "shallow clone lock collision guard" → "a guard against lock collisions in shallow clones".
- One term per concept, every time. Do not alternate *job* / *step* / *task* for the same thing.
- Keep articles: "The assembler runs", not "Assembler runs".
- One subordinate clause per sentence. No em-dash pile-ups.

---

## Fenced blocks for anything runnable

A command, a config snippet, a YAML fragment, an error message, or a stack trace goes in a fenced code block with a language tag — not inline, however short.

Inline backticks *name* a thing. A fenced block holds something the reader runs, pastes, or reads as output.

- `--no-delete` inline (naming the flag)
- Command in a block:
  ```bash
  my-tool deploy --no-delete preview
  ```

Test names go in `#` comments inside the block next to the command that runs them, not in prose beside it:

```bash
dotnet test tests/MyProject.Tests/
# MyMethod_Scenario_Expected — the case being verified
```

---

## Backticks, used liberally

Every identifier gets backticks, every time, including repeat mentions. This covers:

- Types, methods, properties, fields: `MyService.Fetch`, `Cache.ClearStale`
- CLI commands and flags: `my-tool`, `--no-delete`, `--verbose`
- Env vars: `MY_APP_API_KEY`
- File and directory paths: `ci.yml`, `src/MyProject/`
- YAML keys (with trailing colon): `output:`, `items:`
- Config values, labels, package names, branch names, exit codes

Prose that names a symbol bare is wrong even when it reads fine:

| Wrong | Right |
|---|---|
| MyService.Fetch returned void | `MyService.Fetch` returned `void` |
| pass --no-delete | pass `--no-delete` |
| the synthetics job in ci.yml | the `synthetics` job in `ci.yml` |

Do **not** backtick prose nouns that merely share a name with code — the assembler, the scrubber, a profile — unless you mean the literal identifier.

---

## Linking to issues and pull requests

Link liberally. Any issue, PR, or discussion named in prose gets a link — first mention and every repeat.

**Always the full URL.** Never a bare `#3855`, and never a short form like `elastic/repo#3855`. GitHub resolves `#num` against whatever repo the current page lives in — the same body pasted into a different repo silently points at the wrong thing.

Markdown form: `[#3855](https://github.com/elastic/docs-builder/pull/3855)`. Keep the `#num` as link text so it stays scannable in a git log or review tool that strips HTML.

Cross-repo mentions include the org and repo in the link text:

```
[elastic/docs-actions#412](https://github.com/elastic/docs-actions/pull/412)
```

| Wrong | Right |
|---|---|
| See #42 for context | See [#42](https://github.com/org/repo/pull/42) for context |
| other-org/other-repo#7 fixed this | [other-org/other-repo#7](https://github.com/other-org/other-repo/pull/7) fixed this |
| Refs #99 | Refs [#99](https://github.com/org/repo/issues/99) |

---

## Anti-mechanical rules for "What" sections

`## What` uses `####` subheadings, not bullet points. Each subheading names the thing that changed (a file, a command, a concept). The prose under it states what changed and why it matters — two to four sentences, same plain-language rules as everywhere else.

Lead with the behaviour change; name the symbol second when the reviewer needs it to find the code.

| Wrong | Right |
|---|---|
| `` `Cache.ClearStale` sweeps `*.lock` files before each retry `` | A retry clears stale `*.lock` files before it runs |
| `` **`BuildService.Build`**: captures the `GenerateAll` result `` | The build result is captured and written to the output directory |

**Banned openers** for the prose paragraph:
- "Added", "Updated", "Changed", "Refactored", "Modified"
- Any sentence that starts with a file path or a symbol name
- Any paragraph that only restates the subheading

**Three to five `####` sections in a "What".** More than five is a signal the change should be split.

---

## Before/after examples

These are the rules in action. If a new rule does not survive this test, the rule is wrong.

**`## What`, first bullet:**

> ❌ `Cache.ClearStale(IFileSystem, ...)` sweeps `*.lock` files under `.git/` before each retry. Called only from the retry path — never before attempt 1, where a lock could belong to a concurrent process.

> ✅ A retry clears stale `*.lock` files before it runs. The first attempt is never affected — a lock there can belong to a live process.

**Opening of `## Why`:**

> ❌ [#42](https://github.com/org/repo/pull/42) tried to fix stale pool listings by bringing back `registry.json`. That approach was rejected…

> ✅ Scrubbing strips `prs:` from the public copies of private-repo entries. `--prs` joined only on that YAML field, so those entries dropped out with no error.

The history of a rejected PR is not the problem this PR solves. Lead with the problem.
