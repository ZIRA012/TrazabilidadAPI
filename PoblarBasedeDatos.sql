-- Asegúrate de estar conectado a la instancia de SQL Server donde reside la base de datos TrazabilidadDB.
-- Este script poblará la base de datos TrazabilidadDB con datos iniciales.

USE TrazabilidadDB;
GO

-- Activar la inserción explícita de valores en las columnas IDENTITY para todas las tablas.
SET IDENTITY_INSERT dbo.Users ON;
SET IDENTITY_INSERT dbo.Roles ON;
SET IDENTITY_INSERT dbo.UserRoles ON;
SET IDENTITY_INSERT dbo.Procedures ON;
SET IDENTITY_INSERT dbo.Fields ON;
SET IDENTITY_INSERT dbo.DataSets ON;
GO

-- Insertar usuarios en dbo.Users (UserID es IDENTITY)
INSERT INTO dbo.Users (UserID, Username, Password, Email) VALUES
(1, 'admin', 'admin123', 'admin@example.com'),
(2, 'user1', 'user123', 'user1@example.com');
GO

-- Insertar roles en dbo.Roles (RoleID es IDENTITY)
INSERT INTO dbo.Roles (RoleID, RoleName, Description) VALUES
(1, 'Admin', 'Administrator role'),
(2, 'User', 'Regular user role');
GO

-- Insertar relaciones de usuario-rol en dbo.UserRoles (ID es IDENTITY)
INSERT INTO dbo.UserRoles (ID, UserID, RoleID) VALUES
(1, 1, 1),
(2, 2, 2);
GO

-- Insertar los procedimientos con los IDs especificados (ProcedureID es IDENTITY)
INSERT INTO dbo.Procedures (ProcedureID, ProcedureName, Description, CreatedByUserID, LastModifiedUserID) VALUES
(1, 'Data Cleaning', 'Removes duplicates and standardizes formats', 1, 1),
(2, 'Statistical Analysis', 'Performs basic statistical calculations', 1, 1),
(3, 'Data Visualization', 'Creates charts and graphs from data', 2, 2),
(4, 'Machine Learning Model', 'Trains and applies ML models to data', 1, 2),
(5, 'Data Integration', 'Merges data from multiple sources', 2, 1);
GO

-- Insertar campos en dbo.Fields (FieldID es IDENTITY)
INSERT INTO dbo.Fields (FieldID, FieldName, DataType) VALUES
(1, 'SampleField1', 'varchar'),
(2, 'SampleField2', 'int');
GO

-- Insertar datasets en dbo.DataSets (DataSetID es IDENTITY)
INSERT INTO dbo.DataSets (DataSetID, DataSetName, Description, ProcedureID, FieldID) VALUES
(1, 'Sales Data 2023', 'Annual sales figures', 1, 1),
(2, 'Customer Feedback', 'Survey responses from Q2', 2, 2),
(3, 'Website Traffic', 'Daily visitor counts', 3, 2),
(4, 'Product Inventory', 'Current stock levels', 1, 2),
(5, 'Employee Performance', 'Quarterly KPI data', 2, 1),
(6, 'Marketing Campaign Results', 'ROI for recent campaigns', 3, 1),
(7, 'Supply Chain Data', 'Supplier delivery times', 4, 2),
(8, 'Customer Segmentation', 'Demographic clusters', 4, 2),
(9, 'Social Media Metrics', 'Engagement rates across platforms', 3, 1),
(10, 'Financial Forecasts', 'Projected revenue for next FY', 2, 1),
(11, 'Product Returns', 'Reasons for customer returns', 1, 1),
(12, 'Website Heatmaps', 'User interaction patterns', 3, 2),
(13, 'Customer Churn Prediction', 'ML model input data', 4, 2),
(14, 'Competitor Price Analysis', 'Market rate comparisons', 2, 2),
(15, 'IoT Sensor Data', 'Raw data from factory sensors', 5, 2);
GO

-- Desactivar la inserción explícita de valores en las columnas IDENTITY para todas las tablas.
SET IDENTITY_INSERT dbo.Users OFF;
SET IDENTITY_INSERT dbo.Roles OFF;
SET IDENTITY_INSERT dbo.UserRoles OFF;
SET IDENTITY_INSERT dbo.Procedures OFF;
SET IDENTITY_INSERT dbo.Fields OFF;
SET IDENTITY_INSERT dbo.DataSets OFF;
GO