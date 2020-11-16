select 
	b.Id BookId, b.Title, b.Price, b.AuthorId, a.FirstName, a.LastName, s.Amount , bf.FormatType
from 
	Book b
inner join
	Author a on a.Id = b.AuthorId
inner join
	Stock s on s.BookId = b.Id
inner join 
	BookFormat bf on bf.Id = b.FormatId
ORDER BY RANDOM() 
LIMIT @limit
