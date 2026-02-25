Multi-Tenant Invoice Management API (.NET 8)
Overview

This project demonstrates a modular, multi-tenant SaaS billing backend built with ASP.NET Core (.NET 8).

It simulates a shared-database multi-tenant architecture where multiple companies (tenants) use the same application instance while maintaining strict data isolation.

The purpose of this sample is to showcase architectural patterns relevant to migrating a legacy multi-tenant PHP system into a clean, scalable .NET architecture.

Business Context

This API represents a SaaS Invoice Management system where:

Multiple companies use the same platform

Each company manages its own invoices

Tenants cannot access each other's data

The system supports audit tracking and soft delete

Designed with modular layering for maintainability
