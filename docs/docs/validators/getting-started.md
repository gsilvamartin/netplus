# NetPlus.Validators

## Overview

The `NetPlus.Validators` NuGet package provides versatile validation utilities for strings, numerics, and dates, encapsulated into modular components. These utility classes include `StringValidator`, `NumericValidator`, and `DateValidator`, each offering a set of methods to validate and check various properties of the input values.

## Installation

Install the complete `NetPlus.Validators` library or select individual modules based on your validation needs.

### Install the Entire Package

To install the complete `NetPlus.Validators` library, including string, numeric, and date validation modules, use the following command in the Visual Studio terminal:

```bash
Install-Package NetPlus.Validators
```

If you're using the .NET Core command-line interface:

```bash
dotnet add package NetPlus.Validators
```

### Install Individual Modules

Choose specific validation modules to integrate into your project.

#### String Validation Module

```bash
Install-Package NetPlus.Validators.Strings
```

Or using the .NET Core CLI:

```bash
dotnet add package NetPlus.Validators.Strings
```

#### Numeric Validation Module

```bash
Install-Package NetPlus.Validators.Numerics
```

Or using the .NET Core CLI:

```bash
dotnet add package NetPlus.Validators.Numerics
```

#### Date Validation Module

```bash
Install-Package NetPlus.Validators.Dates
```

Or using the .NET Core CLI:

```bash
dotnet add package NetPlus.Validators.Dates
```

## What is NetPlus.Validators?

`NetPlus.Validators` simplifies the process of validating strings, numerics, and dates in your applications. These utility classes provide methods to check various properties, enhancing the reliability and accuracy of your input data validation.

## Module Details

### String Validation Module

The `StringValidator` class includes methods like `IsDate`, `IsDateTime`, and `IsUnicode` to check specific properties of strings. Additionally, it offers methods like `IsEmail`, `IsUrl`, `IsPhoneNumber`, and `IsPostalCode` for extended string validation.

### Numeric Validation Module

The `NumericValidator` class provides methods such as `IsPositive`, `IsNegative`, and `IsZero` to validate numeric values. Other methods like `IsEven`, `IsOdd`, `IsBetween`, and `IsPrime` offer diverse numeric validation options.

### Date Validation Module

The `DateValidator` class offers methods like `IsDate`, `IsFutureDate`, `IsPastDate`, and `IsLeapYear` for validating dates. It includes numerous other methods for specific date checks, ensuring the accuracy of date-related input.

## Note

Ensure that you have the appropriate package source configured in your NuGet package manager. If you're using a private repository, make sure to add the source before attempting to install the packages.

Choose the entire `NetPlus.Validators` package for a comprehensive set of validation tools, or select individual modules based on your application's specific validation requirements. These utility classes are designed to simplify and enhance the validation process in your .NET projects.
