SELECT E.DeviceId, E.Value, E.Status, R.MinThreshold, R.MaxThreshold, R.Location, R.Building, System.TimeStamp as EntryTime 
INTO Alerts
FROM DeviceEvents E
JOIN DeviceReferenceData R
ON E.DeviceId = R.DeviceId
WHERE E.Value < R.MinThreshold
   OR E.Value > R.MaxThreshold 

SELECT E.DeviceId, E.Value, E.Status, R.MinThreshold, R.MaxThreshold, R.Location, R.Building, System.TimeStamp as EntryTime
INTO Telemetry
FROM DeviceEvents E
JOIN DeviceReferenceData R
ON E.DeviceId = R.DeviceId