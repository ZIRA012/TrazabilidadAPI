-- Activar la inserción explícita de valores en la columna IDENTITY para la tabla Users
SET IDENTITY_INSERT dbo.Users ON;

-- Insertar usuarios en dbo.Users (UserID es IDENTITY)
INSERT INTO dbo.Users (UserID, Username, Password, Email) VALUES
(1, 'admin', 'admin123', 'admin@example.com'),
(2, 'user1', 'user123', 'user1@example.com');

-- Desactivar la inserción explícita de valores en la columna IDENTITY para la tabla Users
SET IDENTITY_INSERT dbo.Users OFF;

-- Activar la inserción explícita de valores en la columna IDENTITY para la tabla Roles
SET IDENTITY_INSERT dbo.Roles ON;

-- Insertar roles en dbo.Roles (RoleID es IDENTITY)
INSERT INTO dbo.Roles (RoleID, RoleName, Description) VALUES
(1, 'Admin', 'Administrator role'),
(2, 'User', 'Regular user role');

-- Desactivar la inserción explícita de valores en la columna IDENTITY para la tabla Roles
SET IDENTITY_INSERT dbo.Roles OFF;

-- Activar la inserción explícita de valores en la columna IDENTITY para la tabla UserRoles
SET IDENTITY_INSERT dbo.UserRoles ON;

-- Insertar relaciones de usuario-rol en dbo.UserRoles (ID es IDENTITY)
INSERT INTO dbo.UserRoles (ID, UserID, RoleID) VALUES
(1, 1, 1),
(2, 2, 2);

-- Desactivar la inserción explícita de valores en la columna IDENTITY para la tabla UserRoles
SET IDENTITY_INSERT dbo.UserRoles OFF;

-- Activar la inserción explícita de valores en la columna IDENTITY para la tabla Procedures
SET IDENTITY_INSERT dbo.Procedures ON;

-- Insertar los procedimientos con los IDs especificados
INSERT INTO dbo.Procedures (ProcedureID, ProcedureName, Description, CreatedByUserID, LastModifiedUserID) VALUES
(1, 'Data Cleaning', 'Removes duplicates and standardizes formats', 1, 1),
(2, 'Statistical Analysis', 'Performs basic statistical calculations', 1, 1),
(3, 'Data Visualization', 'Creates charts and graphs from data', 2, 2),
(4, 'Machine Learning Model', 'Trains and applies ML models to data', 1, 2),
(5, 'Data Integration', 'Merges data from multiple sources', 2, 1);

-- Desactivar la inserción explícita de valores en la columna IDENTITY para la tabla Procedures
SET IDENTITY_INSERT dbo.Procedures OFF;

-- Activar la inserción explícita de valores en la columna IDENTITY para la tabla Fields
SET IDENTITY_INSERT dbo.Fields ON;

-- Insertar campos en dbo.Fields (FieldID es IDENTITY)
INSERT INTO dbo.Fields (FieldID, FieldName, DataType) VALUES
(1, 'SampleField1', 'varchar'),
(2, 'SampleField2', 'int');

-- Desactivar la inserción explícita de valores en la columna IDENTITY para la tabla Fields
SET IDENTITY_INSERT dbo.Fields OFF;

-- Activar la inserción explícita de valores en la columna IDENTITY para la tabla DataSets
SET IDENTITY_INSERT dbo.DataSets ON;

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

-- Desactivar la inserción explícita de valores en la columna IDENTITY para la tabla DataSets
SET IDENTITY_INSERT dbo.DataSets OFF;