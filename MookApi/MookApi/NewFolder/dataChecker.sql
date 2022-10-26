

select u.id , u.UserName , r.Name from AspNetUsers u inner join AspNetUserRoles ru on u.Id = ru.UserId inner join AspNetRoles r on r.Id = ru.RoleId


select * from Admins a inner join AspNetUsers u on a.UserId = u.Id


select s.StudentID, s.StudentName, u.UserName from Students s inner join AspNetUsers u on s.userId = u.Id


select rd.RequestHeaderID , COUNT(rd.RequestDetailID) [Count Detail], s.StudentName
from RequestHeader rh full join RequestDetails rd on rh.RequestID = rd.RequestHeaderID inner join students s on rh.StudentID = s.StudentID
GROUP BY rd.RequestHeaderID, s.StudentName
ORDER BY s.StudentName , rd.RequestHeaderID 


select * from comments where CommentFlag = 1 and IsAdminAccepted =0

