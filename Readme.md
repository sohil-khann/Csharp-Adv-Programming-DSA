# C# Advanced Programming & Data Structures and Algorithms (DSA)

Welcome to the **C# Advanced Programming & DSA** repository. This project serves as a comprehensive collection of advanced C# programming concepts and implementations of fundamental Data Structures and Algorithms.

> **Status**: Active Development  
> **Target Framework**: .NET 10.0  
> **Author**: Sohil Khan

---

## Project Overview

This repository is designed to help developers understand and implement complex algorithms and advanced C# features. Each module is focused on a specific category of programming or DSA.

### Currently Implemented

#### 1. Sorting Algorithms (Project: SortingAlgorithms)
- **Bubble Sort**: Optimized implementation with a `swapped` flag. [BubbleSort.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/SortingAlgorithms/BubbleSort.cs)

#### 2. File Handling & Searching (Project: FileHandling)
- **File Handling**:
  - **Byte to Character Stream**: Reading binary data using `StreamReader`. [ByteToCharStream.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/ByteToCharStream.cs)
  - **User Input to File**: Writing console input to files and reading it back. [UserInputToFile.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/UserInputToFile.cs)
- **Linear Search**:
  - **First Negative Number**: Finding the first negative integer in an array. [FirstNegativeSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/FirstNegativeSearch.cs)
  - **Word in Sentences**: Searching for a specific word across multiple sentences. [WordSearchInSentences.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/WordSearchInSentences.cs)
- **Binary Search**:
  - **Rotation Point**: Finding the smallest element in a rotated sorted array. [RotationPointSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/RotationPointSearch.cs)
  - **Peak Element**: Finding an element greater than its neighbors. [PeakElementSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/PeakElementSearch.cs)
  - **2D Matrix Search**: Searching for a target in a sorted 2D matrix. [MatrixBinarySearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/MatrixBinarySearch.cs)
  - **First & Last Occurrence**: Finding range of a target in a sorted array. [FirstLastOccurrenceSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/FirstLastOccurrenceSearch.cs)
- **Challenge Problem**:
  - Combined Linear Search (First Missing Positive) and Binary Search (Target Index). [MissingPositiveAndTargetSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/MissingPositiveAndTargetSearch.cs)

---

## Project Structure

```text
Csharp-Adv-Programming-DSA/
├── SortingAlgorithms/
│   ├── BubbleSort.cs
│   └── Program.cs
├── FileHandling/
│   ├── ByteToCharStream.cs
│   ├── UserInputToFile.cs
│   ├── FirstNegativeSearch.cs
│   ├── WordSearchInSentences.cs
│   ├── RotationPointSearch.cs
│   ├── PeakElementSearch.cs
│   ├── MatrixBinarySearch.cs
│   ├── FirstLastOccurrenceSearch.cs
│   ├── MissingPositiveAndTargetSearch.cs
│   └── Program.cs
├── Readme.md
└── .gitignore
```

---

## Technology Stack

- **C# 12** - Modern C# language features.
- **.NET 10.0** - Latest .NET framework.
- **Visual Studio 2022+** - Recommended IDE.

---

## Getting Started

### Prerequisites
- **.NET 10.0 SDK** installed.

### Running the Projects
1. **Sorting Algorithms**:
   ```bash
   cd SortingAlgorithms
   dotnet run
   ```
2. **File Handling & Search**:
   ```bash
   cd FileHandling
   dotnet run
   ```

---

## Future Roadmap
- [ ] Implement Selection Sort, Insertion Sort, and Quick Sort.
- [ ] Add Data Structures (Linked Lists, Stacks, Queues, Trees).
- [ ] Demonstrate Advanced C# concepts (Delegates, LINQ, Generics).
