INSERT INTO dbo.Articles (Nom,Quantite,Photo,Visible,Description,InventaireId,EnfantInventaireId,CategorieId) VALUES 
('Maracas',5,'https://www.jbd-jouetsenbois.com/images/Image/Maracas_des_animaux_-_JBD_Jouet_en_Bois.jpg',1,'Maracas en bois ',1,NULL,3)
,('piano',4,'https://images-na.ssl-images-amazon.com/images/I/71XjXkQUKgL._SX355_.jpg',1,'piano colore enfants',1,NULL,3)
,('lit',13,'http://www.daillot.com/wp-content/uploads/2015/09/repos-sieste-lits-bebe-enfants-creche-ecole-01-600x480.png',1,'lit 1 place en bois avec barreau de protection',1,NULL,1)
,('paquet de couche',25,'https://www.maison-et-beaute.fr/media/catalog/category/A_712.jpg',1,'couche pampers ',1,NULL,5)
,('body rechange',3,'https://www.bebetshirt.com/1021-thickbox_default/tete-de-panda.jpg',1,'body à tête de panda en rechange ',NULL,1,2)
,('paire de chaussettes ',3,'https://media.vertbaudet.fr/Pictures/vertbaudet/27184/lot-de-3-paires-de-chaussettes-bebe-antiderapantes.jpg?width=457',1,'paire de chaussette : une blanche et une rayée blanche et rose',NULL,3,2)
,('crème rougeur ',1,'https://www.google.ca/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjHg-qytareAhUntIMKHXFMBtcQjRx6BAgBEAU&url=https%3A%2F%2Fwww.pharmarket.com%2Fbepanthen%2Fcreme-5-100g-p1249&psig=AOvVaw1SiZKnLiSDV14vmaBWMNlU&ust=1540860109740648',1,'crème Bépanthen pour le change en cas d''irritations',NULL,2,5)
,('peluche elephant',1,'https://goo.gl/images/HCbeH2',1,'peluche en forme d''éléphant grise',NULL,4,3)
,('tétine moustache',1,'https://goo.gl/images/D6M3af',1,'tétine en forme de moustache noir',NULL,5,5)
,('Biberon',10,'/gestionGarderie/images/articles/icons8-no_camera.png',0,'Biberon',1,NULL,6)
;
INSERT INTO dbo.Articles (Nom,Quantite,Photo,Visible,Description,InventaireId,EnfantInventaireId,CategorieId) VALUES 
('Le livre de la jungle',1,'/gestionGarderie/images/articles/icons8-no_camera.png',1,'Film',1,NULL,7)
,('Shampoing',5,'/gestionGarderie/images/articles/icons8-no_camera.png',0,'Shampoing',1,NULL,5)
,('Action man',5,'/gestionGarderie/images/articles/icons8-no_camera.png',0,'Figurine',1,NULL,3)
,('tables',10,'/gestionGarderie/images/articles/icons8-no_camera.png',0,'table en bois',1,NULL,1)
;