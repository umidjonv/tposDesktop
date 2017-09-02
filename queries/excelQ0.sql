select p.productId, p.name, p.price, p.pack, p.measureId, ex.expenseId, ex.expenseDate, ex.debt,
ex.contragentId, ex.expSum, ex.terminal, ex.prodId, ex.count, ex.packCount, ex.orderSumm 
from product as p
left join 
(select e.expenseId, e.expenseDate, e.debt,e.contragentId, e.expSum, e.terminal, o.prodId, 
o.count, o.packCount, o.orderSumm  from expense as e left join orders as o
on e.expenseId = o.expenseId) as ex
on p.productId = ex.prodId
on 
where ex.orderSumm is not null