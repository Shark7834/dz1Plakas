SELECT * FROM Products
JOIN ColorProducts ON ColorProducts.ColorId=Product.Id
JOIN Color ON ColorProducts.ColorId=Color.Id