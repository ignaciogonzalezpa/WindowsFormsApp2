create database tiendaropa;

use tiendaropa;

create table categorias(
category_id INT PRIMARY KEY auto_increment,
marca varchar (100),
precio varchar (100),
talla varchar (100),
tipo varchar (100), 
descripcion varchar (100)
);
-- prueba 
INSERT INTO categorias (marca ,precio ,talla ,tipo ,descripcion ) VALUES ('sdf' , 'sdf' , 'dfsdf' , 'df' , 'sdf ')