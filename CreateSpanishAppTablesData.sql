--clean up
--drop schema Spanish
--drop table Spanish.SpanishList
--drop table Spanish.SpanishListValue

--create schema
--create schema Spanish

begin transaction

CREATE TABLE [Spanish].[SpanishList](
	[ListId] [bigint] IDENTITY(1,1) NOT NULL,
	[ListName] [varchar](max) NULL,
 CONSTRAINT [PK_SpanishList] PRIMARY KEY CLUSTERED 
(
	[ListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [Spanish].[SpanishListValue](
	[ListValueId] [bigint] IDENTITY(1,1) NOT NULL,
	[ListId] [bigint] NULL,
	[ListEnglishValue] [varchar](max) NULL,
	[ListSpanishValue] [varchar](max) NULL,
 CONSTRAINT [PK_SpanishListValue] PRIMARY KEY CLUSTERED 
(
	[ListValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

select count(*) beforeInsert from Spanish.SpanishList
select count(*) beforeInsert from Spanish.SpanishListValue

--lists ============================================
insert into [Spanish].[SpanishList] select 'The Body'
insert into [Spanish].[SpanishList] select 'xmas2018List'
insert into [Spanish].[SpanishList] select 'MeetupListClothing'
insert into [Spanish].[SpanishList] select 'Colors'
insert into [Spanish].[SpanishList] select 'Family Members'
insert into [Spanish].[SpanishList] select 'Fruits'
insert into [Spanish].[SpanishList] select 'House Terms'
insert into [Spanish].[SpanishList] select 'Map Terms'
insert into [Spanish].[SpanishList] select 'Prepositions Misc'
insert into [Spanish].[SpanishList] select 'Questions'
insert into [Spanish].[SpanishList] select 'Shops'
insert into [Spanish].[SpanishList] select 'Time'
insert into [Spanish].[SpanishList] select 'Vegetables'
insert into [Spanish].[SpanishList] select 'VerbsAR'
insert into [Spanish].[SpanishList] select 'VerbsER'
insert into [Spanish].[SpanishList] select 'VerbsIR'
insert into [Spanish].[SpanishList] select 'Verbs2'
insert into [Spanish].[SpanishList] select 'VerbsA'
insert into [Spanish].[SpanishList] select 'VerbsB'
insert into [Spanish].[SpanishList] select 'VerbsC'
insert into [Spanish].[SpanishList] select 'VerbsD'
insert into [Spanish].[SpanishList] select 'VerbsE'
insert into [Spanish].[SpanishList] select 'VerbsF'
insert into [Spanish].[SpanishList] select 'VerbsG'
insert into [Spanish].[SpanishList] select 'VerbsH'
insert into [Spanish].[SpanishList] select 'VerbsI'
insert into [Spanish].[SpanishList] select 'VerbsJ'
insert into [Spanish].[SpanishList] select 'VerbsK'
insert into [Spanish].[SpanishList] select 'VerbsL'
insert into [Spanish].[SpanishList] select 'VerbsM'
insert into [Spanish].[SpanishList] select 'VerbsN'
insert into [Spanish].[SpanishList] select 'VerbsO'
insert into [Spanish].[SpanishList] select 'VerbsP'
insert into [Spanish].[SpanishList] select 'VerbsQ'
insert into [Spanish].[SpanishList] select 'VerbsR'
insert into [Spanish].[SpanishList] select 'VerbsS'
insert into [Spanish].[SpanishList] select 'VerbsT'
insert into [Spanish].[SpanishList] select 'VerbsU'
insert into [Spanish].[SpanishList] select 'VerbsV'
insert into [Spanish].[SpanishList] select 'VerbsW'
insert into [Spanish].[SpanishList] select 'VerbsX'
insert into [Spanish].[SpanishList] select 'VerbsY'
insert into [Spanish].[SpanishList] select 'VerbsZ'

--specific list ===================================
-- vegetables
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'asparagus', 'el espárrago'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'avocado', 'el aguacate'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'bamboo shoots', 'los tallos de bambú'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'bean', 'el frijol'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'beet', 'la remolacha'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'bok choy', 'la col china'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'broccoli', 'el brócoli'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'Brussels sprout', 'col de Bruselas'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'cabbage', 'la col'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'carrot', 'la zanahoria'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'cassava', 'la yuca'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'cauliflower', 'la coriflor'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'celery', 'el apio'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'chard', 'la acelga'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'chicory', 'la achicoria'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'chickpea', 'el garbanzo'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'corn (American English)', 'el maíz'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'cucumber', 'el pepino'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'eggplant', 'la berenjena'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'endive', 'la endivia'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'garlic', 'el ajo'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'ginger', 'el jengibre'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'green pepper', 'el pimiento verde'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'Jerusalem artichoke', 'el tupinambo'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'jicama', 'la jícama'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'leek', 'el puerro'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'lenti', 'la lenteja'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'rhubarb', 'el ruibarbo'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'lettuce', 'la lechuga'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'mushroom', 'el champiñón'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'okra', 'el quingombó'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'onion', 'la cebolla'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'parsley', 'el perejil'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'parsnip', 'la chirivía'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'pea', 'los guisantes'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'potato', 'la patata'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'pumpkin', 'la calabaza'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'radish', 'el rábano'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'red pepper', 'el pimiento rojo'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'rutabaga', 'el nabo sueco'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'shallot', 'el chalote'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'soybean', 'la semilla de soja'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'spinach', 'las espinacas'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'sorrel', 'la acedera'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'squash', 'la cucurbitácea'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'string beans', 'las habas verdes'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'sweet potato', 'la batata'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'tapioca', 'la tapioca'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'tomatillo', 'el tomatillo'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'tomato', 'el tomate'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'turnip', 'el nabo'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'water chestnut', 'la castaña de agua'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'watercress', 'el berro'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'yam', 'el boniato'
insert into [Spanish].[SpanishListValue] select (select ListId from Spanish.SpanishList where ListName = 'Vegetables'), 'zucchini', 'el calabacín'

--** Start here!!
--insert into [Spanish].[SpanishList] select 'The Body'
--insert into [Spanish].[SpanishList] select 'xmas2018List'
--insert into [Spanish].[SpanishList] select 'MeetupListClothing'
--insert into [Spanish].[SpanishList] select 'Colors'
--insert into [Spanish].[SpanishList] select 'Family Members'
--insert into [Spanish].[SpanishList] select 'Fruits'
--insert into [Spanish].[SpanishList] select 'House Terms'
--insert into [Spanish].[SpanishList] select 'Map Terms'
--insert into [Spanish].[SpanishList] select 'Prepositions Misc'
--insert into [Spanish].[SpanishList] select 'Questions'
--insert into [Spanish].[SpanishList] select 'Shops'
--insert into [Spanish].[SpanishList] select 'Time'
--insert into [Spanish].[SpanishList] select 'Vegetables'
--insert into [Spanish].[SpanishList] select 'VerbsAR'
--insert into [Spanish].[SpanishList] select 'VerbsER'
--insert into [Spanish].[SpanishList] select 'VerbsIR'
--insert into [Spanish].[SpanishList] select 'Verbs2'
--insert into [Spanish].[SpanishList] select 'VerbsA'
--insert into [Spanish].[SpanishList] select 'VerbsB'
--insert into [Spanish].[SpanishList] select 'VerbsC'
--insert into [Spanish].[SpanishList] select 'VerbsD'
--insert into [Spanish].[SpanishList] select 'VerbsE'
--insert into [Spanish].[SpanishList] select 'VerbsF'
--insert into [Spanish].[SpanishList] select 'VerbsG'
--insert into [Spanish].[SpanishList] select 'VerbsH'
--insert into [Spanish].[SpanishList] select 'VerbsI'
--insert into [Spanish].[SpanishList] select 'VerbsJ'
--insert into [Spanish].[SpanishList] select 'VerbsK'
--insert into [Spanish].[SpanishList] select 'VerbsL'
--insert into [Spanish].[SpanishList] select 'VerbsM'
--insert into [Spanish].[SpanishList] select 'VerbsN'
--insert into [Spanish].[SpanishList] select 'VerbsO'
--insert into [Spanish].[SpanishList] select 'VerbsP'
--insert into [Spanish].[SpanishList] select 'VerbsQ'
--insert into [Spanish].[SpanishList] select 'VerbsR'
--insert into [Spanish].[SpanishList] select 'VerbsS'
--insert into [Spanish].[SpanishList] select 'VerbsT'
--insert into [Spanish].[SpanishList] select 'VerbsU'
--insert into [Spanish].[SpanishList] select 'VerbsV'
--insert into [Spanish].[SpanishList] select 'VerbsW'
--insert into [Spanish].[SpanishList] select 'VerbsX'
--insert into [Spanish].[SpanishList] select 'VerbsY'
--insert into [Spanish].[SpanishList] select 'VerbsZ'

select count(*) afterInsert from Spanish.SpanishList
select count(*) afterInsert from Spanish.SpanishListValue

select	sl.ListName, 
		sla.ListEnglishValue,
		sla.ListSpanishValue
from Spanish.SpanishList sl
inner join Spanish.SpanishListValue sla on sl.ListId = sla.ListId
group by sl.ListName, 
		sla.ListEnglishValue,
		sla.ListSpanishValue

rollback
--commit