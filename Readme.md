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
    - [ByteToCharStream.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/ByteToCharStream.cs): Converting binary data to characters using `StreamReader`.
    - [UserInputToFile.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/UserInputToFile.cs): Persisting console input to local storage using `StreamWriter`.
- **Linear Search**: 
    - [FirstNegativeSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/FirstNegativeSearch.cs): Finding the first negative integer in an array.
    - [WordSearchInSentences.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/WordSearchInSentences.cs): Searching for specific keywords across multiple sentences.
- **Binary Search**: 
    - [RotationPointSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/RotationPointSearch.cs): Finding the pivot in a rotated sorted array.
    - [PeakElementSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/PeakElementSearch.cs): Identifying elements greater than their neighbors.
    - [MatrixBinarySearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/MatrixBinarySearch.cs): Efficient searching in 2D sorted matrices.
    - [FirstLastOccurrenceSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/FirstLastOccurrenceSearch.cs): Finding range of indices for target values.
- **Challenge**: 
    - [MissingPositiveAndTargetSearch.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/FileHandling/MissingPositiveAndTargetSearch.cs): Combined Linear and Binary search to find missing integers and target indices.

#### 3. Runtime Performance Analysis (Project: RuntimeAnalysis)
- **Search Analysis**: Comparing Linear vs Binary search performance. [SearchAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/SearchAnalysis.cs)
- **Sorting Analysis**: Comparing Bubble Sort, Merge Sort, and Quick Sort efficiency. [SortingAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/SortingAnalysis.cs)
- **String Analysis**: Performance gap between standard `string` and `StringBuilder`. [StringAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/StringAnalysis.cs)
- **File Reading Analysis**: Efficiency comparison between `StreamReader` and `FileStream`. [FileReadingAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/FileReadingAnalysis.cs)
- **Fibonacci Analysis**: Exponential (Recursive) vs Linear (Iterative) time complexity. [FibonacciAnalysis.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/RuntimeAnalysis/FibonacciAnalysis.cs)

#### 4. Queue Management Use Cases (Project: QueueManagement)
- **Print Job Manager**: Document printing order management. [PrintJobManager.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/QueueManagement/PrintJobManager.cs)
- **Ticket Booking**: Sequential request processing for transport. [TicketBookingSystem.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/QueueManagement/TicketBookingSystem.cs)
- **Task Dispatcher**: Background task worker queue. [TaskDispatcher.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/QueueManagement/TaskDispatcher.cs)
- **Call Center System**: Incoming call routing and agent assignment. [CallCenterManagement.cs](file:///d:/Acess%20meditech/Csharp-Adv-Programming-DSA/QueueManagement/CallCenterManagement.cs)

---

## Project Structure

```text
Csharp-Adv-Programming-DSA/
├── SortingAlgorithms/      # Basic sorting implementations
├── FileHandling/           # File operations and search exercises
├── RuntimeAnalysis/        # Performance comparison modules
├── QueueManagement/        # Real-world Queue and OOP applications
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
4. **Queue Management**:
   ```bash
   cd QueueManagement && dotnet run
   ```

---

## Future Roadmap
- [ ] Add Data Structures (Linked Lists, Stacks, Trees).
- [ ] Demonstrate Advanced C# concepts (Delegates, LINQ, Generics).
