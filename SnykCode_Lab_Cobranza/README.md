# SnykCode Cobranza Lab (intencionalmente vulnerable)

Proyecto de laboratorio .NET 8 para practicar análisis estático con Snyk Code/SAST.
**No es un sistema real de cobranza y no debe desplegarse en producción ni exponerse a Internet.**
Usa datos ficticios y almacenamiento en memoria. Algunas rutas están deliberadamente diseñadas
para que una herramienta SAST pueda detectar patrones inseguros.

## Ejecutar localmente

Requisitos: .NET 8 SDK.

```bash
dotnet restore
dotnet run
```

La API muestra una descripción en `/`. Los endpoints de laboratorio comienzan con `/api`.

## Cómo usarlo en el laboratorio

1. Sube el repositorio a GitHub como repositorio de práctica.
2. Importa/autoriza ese repositorio desde Snyk.
3. Ejecuta Snyk Code (SAST) y revisa cada hallazgo: archivo, línea, severidad, flujo de datos y recomendación.
4. Registra falsos positivos, hallazgos confirmados y controles correctivos.
5. Repite el análisis después de corregir cada vulnerabilidad.

## Hallazgos sembrados intencionalmente

Consulta `LAB_FINDINGS.md` para una lista de referencia. No lo leas antes de ejecutar el primer análisis si quieres hacer el ejercicio a ciegas.

## Nota

El proyecto contiene ejemplos inseguros con fines didácticos, como SQL construido con concatenación,
secretos codificados, credenciales en texto plano, hash débil, token predecible, falta de autorización,
CORS permisivo, traversal de rutas y posible inyección de fórmulas CSV. La detección depende de la
versión de Snyk, el motor, el contexto y la configuración; no todos los patrones necesariamente serán reportados.
