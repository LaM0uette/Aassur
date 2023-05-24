INSERT INTO l_city (insee, postal_code, name, coord_x, coord_y)
SELECT DISTINCT insee, postal, nom, coordX, coordY
FROM laposte
ORDER BY insee, nom;

SELECT * FROM l_city;