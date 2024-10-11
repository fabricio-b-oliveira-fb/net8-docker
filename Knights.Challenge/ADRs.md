# Architectural Documentation

N/A.

## Architecture Haiku

This project is an initiative to assess the technical skills of professionals in the area of ​​Software Engineering.

The core implementation is a CRUD enriched with business rules focused on calculating the Knights' skills.

The calculations are based on the age, physical and personal characteristics provided at the time of character creation.

## Architectural Decision Records (ADRs)

| ADR Id      | Description                                                                              | Status    |
|-------------|------------------------------------------------------------------------------------------|-----------|
| adr-001     | Vue.js               : Frontend application                                              | Approved  |
| adr-002     | C# + .net8           : Backend services (API)                                            | Approved  |
| adr-003     | MongoDB              : Database (NoSql)                                                  | Approved  |
| adr-004     | Docker               : Containerized services (script for building and image generation) | Approved  |
| adr-005     | EKS - AWS            : Kubernetes - production deployment                                | Approved  |
| adr-006     | ELK Stack            : Observability                                                     | Approved  |
| adr-007     | Prometheus           : Monitoring                                                        | Approved  |
| adr-008     | Grafana              : Monitoring (graphic app - chart - feed from Prometheus services   | Approved  |
| adr-009     | Akamai(CDN)          : Increases services security and performance                       | Approved  |
| adr-010     | Api Security         : token-based authentication {Authentication and Authorization}     | Approved  |
| adr-011     | Redis                : Services (API) caching                                            | Approved  |
| adr-012     | Azure devOps         : CI/CD - application deployment                                    | Approved  |
| adr-013     | Software Architecture: Three tier due to controlled complexity                           | Approved  |
| adr-014     | Codebase monitoring  : SonarQube                                                         | Approved  |

## Diagrams

N/A

---

This document must evolve along the project.
