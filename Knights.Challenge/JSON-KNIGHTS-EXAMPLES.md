# Knights - JSON examples

> Use the url http://localhost:8080/swagger/index.html to interact with the knights service

- Create a Knight

- List Knights

- Find a Knight

- Make a Knight a Hero

- List Heroes

## Knight : Goku

{
    "name": "Son Goku",
    "nickname": "Kakaroto",
    "birthday": "2004-10-08T20:36:32.322Z",
    "weapons": [
        {
            "name": "Kamehameha",
            "mod": 5000,
            "attr": "strength",
            "equiped": true
        },
        {
            "name": "Mind",
            "mod": 3000,
            "attr": "charisma",
            "equiped": true
        }
    ],
    "attributes": {
        "strength": 0,
        "dexterity": 0,
        "constitution": 0,
        "intelligence": 0,
        "wisdom": 0,
        "charisma": 0
    },
    "keyAttribute": "strength"
}

## Knight : Vegeta

{
    "name": "Vegeta",
    "nickname": "Saiyajin",
    "birthday": "2006-10-08T20:36:32.322Z",
    "weapons": [
        {
            "name": "Galick Ho",
            "mod": 3000,
            "attr": "strength",
            "equiped": true
        },
        {
            "name": "Mind",
            "mod": 2000,
            "attr": "dexterity",
            "equiped": true
        },
        {
            "name": "Punch",
            "mod": 4000,
            "attr": "intelligence",
            "equiped": true
        }
    ],
    "attributes": {
        "strength": 0,
        "dexterity": 0,
        "constitution": 0,
        "intelligence": 0,
        "wisdom": 0,
        "charisma": 0
    },
    "keyAttribute": "intelligence"
}

---
@@@