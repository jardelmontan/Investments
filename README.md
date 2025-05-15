# Investments

This project simulates the calculation of investment in CDB for knowledge purposes.

## 📁 Solution Structure

This repository contains two applications. They are both together just for convenience.

- **Backend**: A RESTful API built with ASP.NET Core, located in the `src/backend` directory.
- **Frontend**: A single-page application (SPA) developed using Angular, located in the `src/frontend` directory.

Both projects are structured to work together seamlessly, and can be run either independently or using Docker Compose for local development.

## 🚀 Installation (via Docker Compose)

### Prerequisites

- [Docker](https://www.docker.com/get-started) installed
- [Docker Compose](https://docs.docker.com/compose/install/)

### Steps to Run

```bash
# Clone the repository
git clone https://github.com/jardelmontan/Investments.git
cd investments

# Run the application
docker-compose up --build
```

### 🔗 Access URLs

- Frontend: [http://localhost:4200](http://localhost:4200)
- Backend: [http://localhost:5000](http://localhost:5000)

### 🧪 Running Tests

```bash
dotnet test /p:CollectCoverage=true
```
