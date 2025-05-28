# IronSoftwareChallenge - Old Phone Pad - C# Coding Challenge

Repository contains a solution to the Iron Software C# Coding Challenge, which simulates text input using an old mobile phone keypad.

## Problem Description

Given a string of keypresses simulating input on a classic phone keypad. The goal is to decode the sequence into text based on:

- Digits map to letters using a layout (e.g., `2` = A, `22` = B).
- A pause (' ') is required between characters on the same key.
- Asterisk (`*`) acts as a backspace.
- Hash (`#`) signals execute the result.

### Examples
- TextDecoder.Decode("222 2 22#") => "CAB"
- TextDecoder.Decode("33#") => "E"
- TextDecoder.Decode("227*#") => "B"
- TextDecoder.Decode("4433555 555666#") => "HELLO"
- TextDecoder.Decode("8 88777444666*664#") => "TURING"

## Web Interface

This solution includes a fully functional web UI built with ASP.NET 8.0. Users can simulate keypresses by clicking the onscreen buttons.

### Interface Features

- Classic keypad layout with digits and labels (1–9, `*`, `#`)
- Input field showing key sequence
- Output field showing decoded result
- "Clear" button to reset the interface


## Implementation

The decoding logic is implemented in the 'TextDecoder' class, located in:

```
IronSoftwareChallenge/Utils/TextDecoder.cs
```

It handles:
- Input grouping and character cycling
- Delays between same-key presses
- Backspace and end-of-input functionality

---

## Testing

Tests (if included) should go in the `IronSoftwareChallenge.Test`. You can use **xUnit** or your preferred testing framework.


## Requirements

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

---

## How to Run

Build and launch the project with:

```bash
dotnet build
dotnet run --project IronSoftwareChallenge
```

Then visit:

```
https://localhost:7227
```

---

## Submission

This solution is part of the Iron Software coding challenge.

**Author:** Leonid Cáceres  
**Contact:** leonidtej@gmail.com

---

© 2025 Leonid Cáceres