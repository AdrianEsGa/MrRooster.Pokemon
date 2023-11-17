
select * from pokemon

--POKEMON LIST WITH TYPE
SELECT
		pokemon.numero_pokedex AS PokemonId,
		pokemon.nombre		   AS Name,
		tipo.id_tipo		   AS TypeId,
		tipo.nombre			   AS Type,
		altura				   AS Height,
		peso				   AS Weight
FROM
		pokemon
	INNER JOIN
		pokemon_tipo
			ON pokemon.numero_pokedex = pokemon_tipo.numero_pokedex
	INNER JOIN
		tipo
			ON pokemon_tipo.id_tipo = tipo.id_tipo


--POKEMON WITH TYPE AND BASE STATISTICS
SELECT
		pokemon.numero_pokedex		AS PokemonId,
		pokemon.nombre				AS Name,
		tipo.id_tipo				AS TypeId,
		tipo.nombre					AS Type,
		altura						AS Height,
		peso						AS Weight,
		estadisticas_base.PS		AS PS,
		estadisticas_base.ataque	AS Attack,
		estadisticas_base.defensa   AS Defense,
		estadisticas_base.especial  AS Special,
		estadisticas_base.velocidad AS Speed
FROM
		pokemon
	INNER JOIN
		pokemon_tipo
			ON pokemon.numero_pokedex = pokemon_tipo.numero_pokedex
	INNER JOIN
		tipo
			ON pokemon_tipo.id_tipo = tipo.id_tipo
	INNER JOIN
		estadisticas_base
			ON estadisticas_base.numero_pokedex = pokemon.numero_pokedex
WHERE
		pokemon.numero_pokedex = 1


--POKEMON ATTACKS

SELECT
		movimiento.id_movimiento   AS AttackId,
		movimiento.nombre		   AS Name,
		descripcion				   AS Description,
		potencia				   AS Potence,
		precision_mov			   AS Precision,
		PP						   AS PP,
		prioridad				   AS Priority,
		tipo_ataque.id_tipo_ataque AS TypeId,
		tipo_ataque.tipo		   AS TypeName
FROM
		tipo
	INNER JOIN
		movimiento
			ON movimiento.id_tipo = tipo.id_tipo
	INNER JOIN
		tipo_ataque
			ON tipo.id_tipo_ataque = tipo_ataque.id_tipo_ataque
	INNER JOIN
		pokemon_tipo
			ON pokemon_tipo.id_tipo = movimiento.id_tipo
	INNER JOIN
		pokemon
			ON pokemon.numero_pokedex = pokemon_tipo.numero_pokedex

WHERE
		pokemon.numero_pokedex = 1



--POKEMON EVOLUTION
SELECT
		nivel						   AS Level,
		nombre_piedra				   AS Stone,
		forma_evolucion.tipo_evolucion AS TypeId,
		tipo_evolucion.tipo_evolucion  AS TypeName
FROM
		pokemon
	INNER JOIN
		pokemon_forma_evolucion
			ON pokemon.numero_pokedex = pokemon_forma_evolucion.numero_pokedex
	LEFT JOIN
		forma_evolucion
			ON forma_evolucion.id_forma_evolucion = pokemon_forma_evolucion.id_forma_evolucion
	LEFT JOIN
		tipo_evolucion
			ON tipo_evolucion.id_tipo_evolucion = forma_evolucion.tipo_evolucion
	LEFT JOIN
		nivel_evolucion
			ON forma_evolucion.id_forma_evolucion = nivel_evolucion.id_forma_evolucion
	LEFT JOIN
		piedra
			ON piedra.id_forma_evolucion = forma_evolucion.id_forma_evolucion
	LEFT JOIN
		tipo_piedra
			ON piedra.id_tipo_piedra = tipo_piedra.id_tipo_piedra
WHERE
		pokemon.numero_pokedex = 1