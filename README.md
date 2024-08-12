# CMPG323__PROJECT2-41616715

The changes has been approved this file is now a "protect source" file.

## Introduction

The NWU Tech Trends Telemetry API is a RESTful service designed to track the time and cost savings achieved by automations implemented by Tech Trends. This API allows for the creation, retrieval, updating, and deletion of telemetry data, as well as specialized endpoints for calculating cumulative savings by project or client.

# List All Endpoints:

GET /api/telemetry: Retrieves all telemetry entries.

GET /api/telemetry/{id}: Retrieves a telemetry entry by ID.

POST /api/telemetry: Creates a new telemetry entry.

PATCH /api/telemetry/{id}: Updates an existing telemetry entry.

DELETE /api/telemetry/{id}: Deletes a telemetry entry by ID.

GET /api/telemetry/GetSavingsByProject: Retrieves cumulative time and cost savings for a project.

GET /api/telemetry/GetSavingsByClient: Retrieves cumulative time and cost savings for a client.
