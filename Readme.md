#  Eco-Ride Urban Mobility System

Welcome to the **Eco-Ride Urban Mobility System** - A C# demonstration of Object-Oriented Programming principles with abstract classes, inheritance, and polymorphism.

>  **Status**: Active Development  
>  **Target Framework**: .NET 10.0  
>  **IDE**: Visual Studio 2022+  
>  **Author**: Sohil Khan

---

##  Project Overview

Eco-Ride is an urban mobility management system designed to handle multiple types of electric vehicles including cars and scooters. The project demonstrates core OOP concepts through a vehicle rental system that calculates trip costs for different vehicle types based on distance traveled.

### Key Features
-  **Electric Car** - Seating capacity management with distance-based trip cost calculation
-  **Electric Scooter** - Speed limit tracking with trip cost calculation
-  **Battery Management** - Percentage-based battery status tracking
-  **Dynamic Pricing** - Vehicle-specific cost calculation algorithms
-  **Maintenance Tracking** - Vehicle maintenance status monitoring
-  **Rental Pricing** - Configurable rental price management

---

##  Project Architecture

### Class Hierarchy

```
Vehicle (Abstract Base Class)
├── ElectricCar
│   └── Seating Capacity: 5 passengers
│   └── Cost: Base Rate $5 + $0.5 per km
└── ElectricScooter
    └── Max Speed Limit: 25 km/h
    └── Cost: Base Rate $1 + $0.15 per km
```

### Core Classes

#### **Vehicle.cs** (Abstract Base Class)
- **Abstract Method**: `calculate_trip_cost(int distance)` - To be implemented by subclasses
- **Properties**: 
  - Vehicle ID and Model
  - Battery Percentage (0-100 validation)
  - Maintenance Status
  - Rental Price
- **Methods**: Getter and setter methods for all properties

#### **ElectricCar.cs** (Inherits from Vehicle)
- **Constructor**: Takes vehicle ID, model name, and seating capacity
- **Seating Capacity**: Stores passenger capacity (default: 5)
- **Trip Cost Calculation**: `(5 + 0.5) × distance`
  - Designed for longer urban commutes
  
#### **ElectricScooter.cs** (Inherits from Vehicle)
- **Constructor**: Takes vehicle ID, model name, and max speed limit
- **Speed Limit**: Maximum operating speed (default: 25 km/h)
- **Trip Cost Calculation**: `(1 + 0.15) × distance`
  - Designed for short-distance urban trips

#### **EcoRideMain.cs** (Entry Point)
- Demonstrates vehicle instantiation
- Shows trip cost calculation for both vehicle types
- Sample implementation with Tesla Model 3 and Xiaomi Electric Scooter

---

##  Technology Stack

- **C# 12** - Modern .NET with latest language features
- **.NET 10.0** - Latest framework with enhanced performance
- **Visual Studio 2022+** - Professional development environment
- **Object-Oriented Programming** - Abstract classes, inheritance, polymorphism
- **Nullable Reference Types** - Modern C# safety features
- **Implicit Usings** - Clean code practices

---

##  Project Structure

```
Eco-Ride/
├── Vehicle.cs              # Abstract base class for all vehicles
├── ElectricCar.cs          # Electric car implementation
├── ElectricScooter.cs      # Electric scooter implementation
├── EcoRideMain.cs          # Application entry point and demo
├── Eco-Ride.csproj         # Project configuration file
├── Readme.md              # This file
└── .gitignore             # Git ignore configuration
```

---

##  Getting Started

### Prerequisites
- **.NET 10.0 SDK** installed
- **Visual Studio 2022** or **Visual Studio Code** with C# extension
- **Git** for version control

### Setup & Running

1. **Clone the repository**:
   ```bash
   git clone https://github.com/sohil-khann/cshap-baasic-to-advance-extra-problems.git
   cd Eco-Ride
   ```

2. **Build the project**:
   ```bash
   dotnet build
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

### Sample Output

```
Welcome to Eco-Ride Urban Mobility System
Trip cost for Electric Car: $55
Trip cost for Electric Scooter: $11.5
```

---

## Usage Examples

### Creating an Electric Car
```csharp
ElectricCar car = new ElectricCar("EC1001", "Tesla Model 3", 5);
double costFor10km = car.calculate_trip_cost(10); // Returns $55
```

### Creating an Electric Scooter
```csharp
ElectricScooter scooter = new ElectricScooter("ES2001", "Xiaomi Mi Electric Scooter", 25);
double costFor10km = scooter.calculate_trip_cost(10); // Returns $11.5
```

### Managing Vehicle Properties
```csharp
car.SetBatteryPercentage(85);          // Set battery to 85%
car.SetMaintenanceStatus(true);        // Mark as under maintenance
car.SetRentalPrice(150);               // Set rental price to $150

int rentalPrice = car.GetRentalPrice(); // Retrieve rental price
bool inMaintenance = car.GetMaintenanceStatus(); // Check maintenance status
```

---

##  Learning Objectives

This project demonstrates:

- **Abstract Classes**: Using `Vehicle` as an abstract base class
- **Inheritance**: `ElectricCar` and `ElectricScooter` inherit from `Vehicle`
- **Polymorphism**: Different implementations of `calculate_trip_cost()` method
- **Encapsulation**: Private fields with public getter/setter methods
- **Object-Oriented Design**: Single Responsibility Principle for each class
- **Input Validation**: Battery percentage validation (0-100 range)
- **Practical Application**: Real-world problem solving through OOP

---

##  OOP Principles Applied

| Principle | Implementation |
|-----------|-----------------|
| **Abstraction** | `Vehicle` abstract class with abstract method |
| **Inheritance** | `ElectricCar` and `ElectricScooter` extend `Vehicle` |
| **Polymorphism** | Each vehicle type has its own `calculate_trip_cost()` logic |
| **Encapsulation** | Private fields with public accessors and mutators |
| **Validation** | Battery percentage bounds checking |

---

##  Future Enhancements

- **User Interface**: Console menu system for vehicle selection
- **Data Persistence**: Save/load vehicle data to JSON/database
- **Route Planning**: Integration with mapping APIs
- **Payment System**: Transaction processing and history
- **User Accounts**: Login system and booking history
- **Unit Testing**: Comprehensive test coverage with xUnit
- **Performance Metrics**: Trip statistics and analytics
- **Booking System**: Reservation and availability management

---

##  Contributing

This is a learning project demonstrating OOP principles in C#. Contributions, suggestions, and improvements are welcome!

---

##  License

This project is part of the BridgeLabz .NET Fullstack Training program.

---

*Last Updated: January 5, 2026*  
*Author: Sohil Khan*

