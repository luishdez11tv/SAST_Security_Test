# Guía de instructor: vulnerabilidades sembradas

Ejecuta primero el análisis sin consultar esta lista si quieres comprobar SnykCode a ciegas.
Los nombres de archivo y los patrones son una guía, no una promesa de que cada regla aparezca en todas las versiones.

1. **SQL Injection** — `Utilities/SqlQueryBuilder.cs`: consultas SQL concatenan/interpolan entradas (`name`, `status`, `sortColumn`, `taxId`, `reference`).
2. **Hard-coded secret** — `Security/LegacyCredentialService.cs`: `ApiSecret` está codificado en el código fuente.
3. **Credenciales en texto plano** — `Data/DemoStore.cs` y `LegacyCredentialService.Validate`: usuarios de demostración guardan/comparan contraseñas directamente.
4. **Hash de contraseña débil (SHA-1)** — `LegacyCredentialService.HashPasswordWeakly`.
5. **Generación de token predecible** — `LegacyCredentialService.CreateResetToken` usa `Random` para un token de restablecimiento.
6. **Broken Access Control / IDOR** — `InvoicesController.Get`, `ForCustomer`, endpoints de pagos y reportes no verifican identidad, rol ni pertenencia del recurso.
7. **CORS excesivamente permisivo** — `Program.cs`: `AllowAnyOrigin`, `AllowAnyHeader`, `AllowAnyMethod`.
8. **Path Traversal** — `Utilities/ExportService.cs`: combina un nombre controlado por el usuario con una ruta y no valida la ruta canónica.
9. **Divulgación de información sensible** — `ReportsController.Export` devuelve la ruta absoluta del servidor; respuestas y datos financieros no requieren autorización.
10. **CSV Formula Injection** — `Services/ReportService.cs`: datos de campos exportados no neutralizan fórmulas de hojas de cálculo.
11. **Exposición de secreto como token** — `AuthController.Login`: devuelve el secreto estático como token de acceso.
12. **Falta de autenticación/autorización** — `Program.cs` no configura autenticación ni autorización, mientras los controladores exponen datos y operaciones.
13. **Reflejo de entrada en header** — `CustomersController.Search`: refleja `q` en una cabecera HTTP sin validación explícita (la explotabilidad depende del servidor/framework).
14. **Validación insuficiente de entradas** — los controladores aceptan modelos con validación de negocio limitada.

## Recomendaciones de corrección

- Usar consultas parametrizadas y permitir-listas para columnas de ordenamiento.
- Mover secretos a un almacén de secretos/variables seguras y rotarlos.
- Usar ASP.NET Core Identity o un proveedor de identidad; almacenar hashes resistentes con sal (Argon2id, bcrypt o PBKDF2).
- Generar tokens con `RandomNumberGenerator`, con expiración, un solo uso, rate limiting y verificación de identidad.
- Añadir autenticación y políticas de autorización; comprobar ownership en cada recurso.
- Restringir CORS a los orígenes necesarios.
- Normalizar y validar rutas contra una carpeta base; rechazar rutas fuera de ella.
- Neutralizar caracteres de fórmula en CSV y evitar divulgar rutas internas.
- Validar DTOs y aplicar límites de tasa, auditoría y manejo seguro de errores.
