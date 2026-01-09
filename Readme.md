﻿# C# Advanced Programming & Data Structures and Algorithms (DSA)

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
- **File Handling**: Byte to Character Stream, User Input to File.
- **Searching**: Linear Search (First Negative, Word in Sentences), Binary Search (Rotation Point, Peak Element, 2D Matrix, Occurrences).
- **Challenge**: Missing Positive & Target Index Search.

#### 3. Runtime Performance Analysis (Project: RuntimeAnalysis)
- **Search Analysis**: Comparing Linear vs Binary search performance. [SearchAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/SearchAnalysis.cs)
- **Sorting Analysis**: Comparing Bubble Sort, Merge Sort, and Quick Sort. [SortingAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/SortingAnalysis.cs)
- **String Analysis**: Comparing standard `string` vs `StringBuilder` concatenation. [StringAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/StringAnalysis.cs)
- **File Reading Analysis**: Comparing `StreamReader` vs `FileStream` for large file access. [FileReadingAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/FileReadingAnalysis.cs)
- **Fibonacci Analysis**: Comparing Recursive vs Iterative Fibonacci efficiency. [FibonacciAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/FibonacciAnalysis.cs)

---

## Project Structure

```text
Csharp-Adv-Programming-DSA/
├── SortingAlgorithms/      # Basic sorting implementations
├── FileHandling/           # File operations and search exercises
├── RuntimeAnalysis/        # Performance comparison modules
├── LinkedLists/            # Linked List implementations
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
   cd SortingAlgorithms && dotnet run
   ```
2. **File Handling & Search**:
   ```bash
   cd FileHandling && dotnet run
   ```
3. **Runtime Analysis**:
   ```bash
   cd RuntimeAnalysis && dotnet run
   ```

---

## Future Roadmap
- [ ] Add Data Structures (Linked Lists, Stacks, Queues, Trees).
- [ ] Demonstrate Advanced C# concepts (Delegates, LINQ, Generics).