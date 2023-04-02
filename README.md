# Finstar
2 Часть. SQL запросы:

1. Написать запрос, который возвращает наименование клиентов и кол-во
контактов клиентов.\n
Select Name, count(ClientId)\n
From Clients as cl\n
Join Contacts as con\n
on cl.Id = con.ClientId\n
group by Name\n

2. Написать запрос, который возвращает список клиентов, у которых есть более
2 контактов.\n
Select name\n
From (1-ая задача) q\n
Where count > 2\n
