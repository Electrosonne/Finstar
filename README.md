# Finstar
2 Часть. SQL запросы:  
  
1. Написать запрос, который возвращает наименование клиентов и кол-во
контактов клиентов.  
Select Name, count(ClientId)  
From Clients as cl  
Join Contacts as con  
on cl.Id = con.ClientId  
group by Name  
  
2. Написать запрос, который возвращает список клиентов, у которых есть более
2 контактов.  
Select name  
From (1-ая задача) q  
Where count > 2  
