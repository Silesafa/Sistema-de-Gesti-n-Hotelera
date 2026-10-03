# 🏨 Sistema de Gestión Hotelera — Web API RESTful & ASP.NET Core MVC

Este proyecto corresponde a la segunda etapa del desarrollo del sistema de gestión hotelera para la asignatura **Fundamentos en Programación Web (Código 03075)** de la Universidad Estatal a Distancia (UNED).

La solución evoluciona la arquitectura hacia un modelo desacoplado utilizando una **Web API RESTful independiente** para la lógica del negocio y almacenamiento en memoria, consumida por un cliente **Web ASP.NET Core MVC**.

---

## 🛠️ Tecnologías y Herramientas

- **IDE:** Visual Studio Community 2026
- **Lenguaje:** C# / .NET 10.0
- **Servicios:** ASP.NET Core Web API (RESTful Services)
- **Interfaz Web:** ASP.NET Core MVC
- **Persistencia:** Almacenamiento en Memoria / Cache
- **Arquitectura:** Modelo-Vista-Controlador (MVC) + Cliente-Servidor HTTP

---

## 🚀 Arquitectura y Módulos

La solución se compone de dos proyectos principales dentro del mismo archivo `.sln`:

### 1. 📡 Proyecto RESTful Services (`Proyecto2API`)
Expone endpoints HTTP (GET, POST, PUT, DELETE) para gestionar las entidades del negocio:
- **Empleados:** Operaciones CRUD completas para la gestión del personal.
- **Clientes:** Operaciones CRUD completas para el catálogo de clientes.
- **Habitaciones:** Operaciones CRUD completas y control de estados de habitaciones.
- **Reservaciones:** Lógica de reservas, cálculo automático de tarifas, descuentos, IVA (13%), estados y validación de traslape de fechas en memoria.

### 2. 💻 Proyecto Web MVC (`Proyecto1MVC`)
Capa de presentación que consume la API RESTful mediante `HttpClient`:
- **Navegación:** Menú fluido entre Clientes, Empleados, Habitaciones y Reservaciones.
- **Módulos de Búsqueda:** Búsquedas independientes por cédula, número de habitación o código de reserva.
- **Validaciones:** Control de reglas de negocio en la UI y manejo de restricciones (evita eliminar clientes/habitaciones con reservas activas).

---

## ⚙️ Pasos para la Ejecución

1. Clonar el repositorio:
   ```bash
   git clone [https://github.com/Silesafa/Sistema-de-Gesti-n-Hotelera.git](https://github.com/Silesafa/Sistema-de-Gesti-n-Hotelera.git)
