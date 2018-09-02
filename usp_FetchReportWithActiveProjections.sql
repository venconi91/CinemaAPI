CREATE PROCEDURE usp_FetchReportWithActiveProjections
AS  
BEGIN  
	SELECT p.Id AS ProjectionId,
		   m.Name AS MovieName,
		   c.Name AS CinemaName,
		   r.Number AS RoomNumber,
		   p.StartDate AS MovieStartDate,
		   (SELECT COUNT(*) FROM Reservations res WHERE res.ProjectionId = p.Id) AS Reservations,
		   (SELECT (r.Rows * r.SeatsPerRow) - (SELECT COUNT(*)  FROM Reservations res WHERE res.ProjectionId = p.Id)) AS AvailableSeats
	FROM Projections p
	JOIN Movies m
	ON p.MovieId = m.Id
	JOIN Rooms r
	ON p.RoomId = r.Id
	JOIN Cinemas c
	ON r.cinemaId = c.Id
	WHERE p.StartDate > GETDATE()
END