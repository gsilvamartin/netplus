# NetPlus.Generator

## Overview

The `NetPlus.Generator` NuGet package is a powerful toolset for generating random data, GUIDs, and passwords in your applications. This library includes modules for data generation, GUID generation, and password generation, providing flexible and efficient utilities.

## Installation

You can install the entire `NetPlus.Generator` package or choose specific modules to meet your project requirements.

### Install the Entire Package

To install the complete `NetPlus.Generator` library, which includes data generation, GUID generation, and password generation modules, use the following command in the Visual Studio terminal:

```bash
Install-Package NetPlus.Generator
```

If you're using the .NET Core command-line interface:

```bash
dotnet add package NetPlus.Generator
```

### Install Individual Modules

Tailor your data generation toolkit by selectively installing specific modules.

#### Data Generation Module

```bash
Install-Package NetPlus.Generator.Data
```

Or using the .NET Core CLI:

```bash
dotnet add package NetPlus.Generator.Data
```

#### GUID Generation Module

```bash
Install-Package NetPlus.Generator.Guid
```

Or using the .NET Core CLI:

```bash
dotnet add package NetPlus.Generator.Guid
```

#### Password Generation Module

```bash
Install-Package NetPlus.Generator.Password
```

Or using the .NET Core CLI:

```bash
dotnet add package NetPlus.Generator.Password
```

## What is NetPlus.Generator?

`NetPlus.Generator` simplifies the task of generating random data, GUIDs, and passwords in your applications. Whether you need to populate test data, create unique identifiers, or enhance security with robust passwords, this library provides efficient and reliable solutions.

## Module Details

### Data Generation Module

The Data Generation module includes a `DataGenerator` class with methods for generating random data of specified types. It uses reflection to create instances with random property values.

### GUID Generation Module

The GUID Generation module introduces a `GuidGenerator` class offering methods for generating new GUIDs in various formats, including string, byte array, and Base64 string.

### Password Generation Module

The Password Generation module provides a `PasswordGenerator` class with methods for generating random passwords. You can customize the length, allowed characters, and the number of non-alphanumeric characters in the generated passwords.

## Note

Ensure that you have the appropriate package source configured in your NuGet package manager. If you're using a private repository, make sure to add the source before attempting to install the packages.

Select the entire `NetPlus.Generator` package for a comprehensive set of generation tools, or choose specific modules based on your application's needs. These generation utilities add versatility to your code, addressing common scenarios that require random data, GUIDs, or secure passwords.
