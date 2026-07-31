# Employee CRUD API

API REST desarrollada en **C# / ASP.NET Core (Minimal APIs)** para la gestión
de empleados, implementada con almacenamiento en memoria y una arquitectura
en capas que sigue los principios **SOLID**.

Proyecto desarrollado como práctica de la metodología **Git Flow**, con ramas
`feature/` y Pull Requests hacia `dev`, `qa` y `main`.

---

## 📌 Descripción

El proyecto expone un CRUD completo de **Empleados**, permitiendo:

- Listar todos los empleados
- Consultar un empleado por ID
- Crear un nuevo empleado
- Actualizar un empleado existente
- Eliminar un empleado

Los datos se almacenan **en memoria** (no requiere base de datos), lo que
facilita ejecutar y probar el proyecto sin configuración adicional.

---

## 🏗️ Arquitectura

El proyecto está organizado en capas independientes, cada una con una única
responsabilidad, aplicando **Inversión de Dependencias** mediante interfaces:

```
EmployeeCrudApi/
├── Models/          → Entidad de dominio (Employee)
├── DTOs/            → Objetos de transferencia de datos (Create/Update)
├── Repositories/    → Acceso a datos (interfaz + implementación en memoria)
├── Validation/       → Reglas de validación de entrada
├── Services/         → Lógica de negocio (orquesta repositorio + validación)
├── Endpoints/        → Definición de rutas HTTP (capa de presentación)
└── Program.cs        → Composition root (inyección de dependencias)
```

| Principio SOLID | Aplicación en el proyecto |
|---|---|
| **S**ingle Responsibility | Cada capa tiene una única razón para cambiar (persistencia, validación, negocio, presentación) |
| **O**pen/Closed | Los endpoints se agregan como extensión (`MapEmployeeEndpoints`) sin modificar `Program.cs` |
| **L**iskov Substitution | Cualquier implementación de `IEmployeeRepository` o `IEmployeeValidator` puede sustituir a la actual sin romper el sistema |
| **I**nterface Segregation | Interfaces pequeñas y específicas (`IEmployeeRepository`, `IEmployeeValidator`, `IEmployeeService`) |
| **D**ependency Inversion | El servicio depende de abstracciones (`IEmployeeRepository`, `IEmployeeValidator`), no de implementaciones concretas |

---

## 🚀 Cómo ejecutar el proyecto

### Requisitos
- [.NET SDK 8.0](https://dotnet.microsoft.com/download) o superior

### Pasos

```bash
git clone https://github.com/TU_USUARIO/employee-crud-api.git
cd employee-crud-api
dotnet run
```

La API quedará disponible en `http://localhost:5000` (el puerto exacto se
muestra en la consola al iniciar).

---

## 📡 Endpoints disponibles

| Método | Ruta | Descripción |
|---|---|---|
| `GET` | `/api/employees` | Lista todos los empleados |
| `GET` | `/api/employees/{id}` | Obtiene un empleado por ID |
| `POST` | `/api/employees` | Crea un nuevo empleado |
| `PUT` | `/api/employees/{id}` | Actualiza un empleado existente |
| `DELETE` | `/api/employees/{id}` | Elimina un empleado |

### Ejemplo de body para `POST` / `PUT`

```json
{
  "firstName": "Ana",
  "lastName": "Pérez",
  "email": "ana@example.com",
  "position": "Developer",
  "hireDate": "2025-01-15T00:00:00"
}
```

### Validaciones aplicadas

- `firstName`, `lastName` y `position` son obligatorios.
- `email` debe tener un formato válido y ser único entre empleados.
- `hireDate` no puede ser una fecha futura.

---

## 🌿 Flujo de trabajo (Git Flow)

El desarrollo se organizó en **5 ramas `feature/`**, una por cada capa de la
arquitectura, siguiendo el flujo:

```
feature/... → dev → qa → main
```

| Rama | Contenido |
|---|---|
| `feature/employee-domain-layer` | Modelo `Employee` y DTOs |
| `feature/employee-repository-layer` | Repositorio en memoria |
| `feature/employee-validation-layer` | Validaciones de entrada |
| `feature/employee-service-layer` | Lógica de negocio |
| `feature/employee-api-layer` | Endpoints y configuración final |

Cada rama generó **3 Pull Requests** (hacia `dev`, `qa` y `main`), todos
cerrados/fusionados, integrando el proyecto de forma incremental hasta
quedar completo en `main`.

---

## 🛠️ Tecnologías

- C# / .NET 8
- ASP.NET Core Minimal APIs
- Arquitectura en capas (SOLID)
