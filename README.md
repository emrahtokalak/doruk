# Doruk

![Doruk Logo](doruk.png)

Doruk is a collection of open-source modules designed to enrich **Orchard Core**, a powerful application framework built on **ASP.NET Core**.

## Overview

Orchard Core provides a **flexible and scalable** foundation for building dynamic and data-driven websites and applications. Doruk modules are developed to take this framework further, focusing on:

- **Modularity** – Independent modules allow for seamless integration according to project requirements.
- **Security** – Designed in accordance with industry standards to ensure application security.
- **Performance** – Optimized for speed and efficiency to maximize Orchard Core's potential.

## Project Structure

The Doruk repository is organized for clarity and ease of use. You can find all modules in the `src/Modules`
folder; each is structured for independent use and configuration.

- **Modules Folder:**
  Contains all Doruk modules. Each module has a `README.md` file with installation and integration details.

### Example Structure
```
src/
└── Modules/
    ├── Doruk.Queries/
    │   ├── README.md
    │   ├── Manifest.cs
    │   ├── ...
    └── OtherModules/
        ├── README.md
        ├── ...
```

## Planned Modules

The following modules are planned for development and inclusion in the Doruk collection:

- Doruk.Queries
- Doruk.GraphQL
- Doruk.Liquid
- Doruk.Scripting
- Doruk.VueForms
- Doruk.DynamicTable
- Doruk.Search


To get started with any module, refer to its respective `README.md` file for detailed setup instructions.
