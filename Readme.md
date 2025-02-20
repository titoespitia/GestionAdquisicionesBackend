# 📌 Sistema de Gestión de Adquisiciones - Backend

Este proyecto es una **API REST** desarrollada con **.NET 9 y MediatR**, que permite gestionar adquisiciones y su historial de modificaciones.  
El sistema está diseñado con **arquitectura limpia** y usa una **base de datos en memoria** para pruebas rápidas.

---

## 🚀 Tecnologías Utilizadas
- **.NET 9**
- **C#**
- **MediatR** (Manejo de CQRS)
- **Entity Framework Core** (Base de datos en memoria)
- **Scalar** (Documentación de API)
- **InMemoryDatabase** (Persistencia de datos en memoria)
- **DDD** (Diseño orientado al dominio)

---

## 📂 Estructura del Proyecto
```
📂 GestionAdquisiciones.sln
│
├── 📂 GestionAdquisiciones.API       # Capa de Presentación (Web API)
│   ├── 📂 Controladores              # Endpoints de Adquisiciones e Historial
│   ├── 📄 Program.cs                 # Configuración de la API
│
├── 📂 GestionAdquisiciones.Aplicacion # Capa de Aplicación (Casos de Uso)
│   ├── 📂 CasosDeUso                 # Handlers de MediatR
│
├── 📂 GestionAdquisiciones.Dominio    # Capa de Dominio (Reglas de Negocio)
│   ├── 📂 Entidades                  # Modelos y Lógica de Negocio
│   ├── 📂 Interfaces                  # Contratos de Servicios y Repositorios
│
├── 📂 GestionAdquisiciones.Infraestructura # Capa de Infraestructura (Persistencia)
│   ├── 📂 Persistencia               # Contexto de Base de Datos y Configuración
│   ├── 📂 Repositorios               # Implementaciones de los repositorios
│
├── 📄 README.md                      # Documentación del Proyecto
```
---

## 📦 Instalación y Configuración

### **1️⃣ Requisitos Previos**
- **.NET 9 SDK** instalado en tu máquina.
- **Visual Studio / Visual Studio Code**.
- **Postman o Scalar** para probar la API.

### **2️⃣ Clonar el Repositorio**
```sh
git clone https://github.com/tuusuario/gestion-adquisiciones.git
cd gestion-adquisiciones
```

### **3️⃣ Restaurar Dependencias**
```sh
dotnet restore
```

### **4️⃣ Ejecutar la Aplicación**
```sh
dotnet run --project GestionAdquisiciones.API
```

> **Nota:** Se ejecutará en `http://localhost:5000` por defecto.

---

## 📖 Endpoints Disponibles
### **🔹 Adquisiciones**
| Método  | Endpoint                     | Descripción |
|---------|------------------------------|-------------|
| `POST`  | `/api/adquisiciones`         | Crear una adquisición |
| `GET`   | `/api/adquisiciones`         | Obtener todas las adquisiciones |
| `GET`   | `/api/adquisiciones/{id}`    | Obtener una adquisición por ID |
| `PUT`   | `/api/adquisiciones/{id}`    | Modificar una adquisición |
| `PUT`| `/api/adquisiciones/{id}/desactivar`    | Desactivar una adquisición |

### **🔹 Historial**
| Método  | Endpoint                          | Descripción |
|---------|-----------------------------------|-------------|
| `GET`   | `/api/historial/{adquisicionId}` | Obtener historial de cambios de una adquisición |

---

## 🔧 Configuración Adicional
### **🛠️ Base de Datos en Memoria**
El proyecto utiliza **InMemoryDatabase** para pruebas rápidas. Los datos de prueba se cargan automáticamente en la inicialización.

📌 **Para modificar la data semilla**, edita el archivo:  
📂 GestionAdquisiciones.Infraestructura  
│── 📂 Persistencia  
│   ├── 📄 InicializadorBaseDatos.cs  

---

## 📋 Pruebas con Scalar
1️⃣ Ejecuta la aplicación con `dotnet run --project GestionAdquisiciones.API`.  
2️⃣ Abre tu navegador y ve a:  
   👉 [`http://localhost:5195/scalar/v1`](http://localhost:5195/scalar/v1)  
3️⃣ Prueba los endpoints directamente desde la interfaz de Swagger.
