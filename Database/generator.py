from mimesis import Person
from mimesis.enums import Gender
from random import randint
from mimesis import Generic
from mimesis import locales
from random import choice

genre_list = ["Comedy", "Drama", "Horror", "Crime", "Fantasy",\
     "Animation", "Action", "Science Fiction", "Documentary"]

film_sites_list = ["Shetflix", "FilmSearch", "H20", "eve"]

def generate_actors():
    f = open("actors.csv", 'w')
    person = Person()
    id_PK = 1
    
    for _ in range(2500):
        # generate male  
        id_FK = randint(1, 1000)

        f.write(str(id_PK) + ',' + str(id_FK) + ','\
         + person.full_name(gender=Gender.MALE) + ','\
         + str(person.age(minimum=18, maximum=70)) + ','\
         + 'M' + ','\
         + person.nationality() + ','\
         + str(randint(1000, 1000000)) + ','\
         + str(randint(0, 5)) + '\n')

        id_PK += 1
        id_FK = randint(1, 1000)
        # generate female
        f.write(str(id_PK) + ','+ str(id_FK) + ','\
         + person.full_name(gender=Gender.FEMALE) + ','\
         + str(person.age(minimum=18, maximum=70)) + ','\
         + 'F' + ','\
         + person.nationality() + ','\
         + str(randint(1000, 1000000)) + ','\
         + str(randint(0, 5)) + '\n')
        
        id_PK += 1

    f.close()

def studio_creation_date_generate():
    day = str(randint(1, 28))
    month = str(randint(1, 12))
    year = str(randint(1960, 2010))
    return year + '-' + month + '-' + day


def film_creation_date_generate():
    day = str(randint(1, 28))
    month = str(randint(1, 12))
    year = str(randint(1990, 2020))
    return year + '-' + month + '-' + day

def generate_studios():
    f = open("studios.csv", 'w')
    gen = Generic(locales.EN)

    for i in range(1000):
        f.write(str(i + 1) + ',' 
        + gen.text.word() + " studio" + ','
        + studio_creation_date_generate() + '\n')

    f.close()


def generate_directors():
    f = open("directors.csv", 'w')
    person = Person()
    ID = 1
    for _ in range(500):
        # generate male
        f.write(str(ID) + ','\
         + person.full_name(gender=Gender.MALE) + ','\
         + str(person.age(minimum=24, maximum=70)) + ','\
         + 'M' + ','\
         + str(randint(1, 9)) + '\n')

        ID += 1
        # generate female
        f.write(str(ID) + ','\
         + person.full_name(gender=Gender.FEMALE) + ','\
         + str(person.age(minimum=24, maximum=70)) + ','\
         + 'F' + ','\
         + str(randint(1, 9)) + '\n')

        ID += 1

    f.close()

def random_genre_generate():
    return choice(genre_list)

def generate_genres():
    f = open("genres.csv", 'w')  

    for i in range(len(genre_list)):
        f.write(str(i + 1) + ',' + genre_list[i] + '\n')

    f.close() 

def generate_films():
    f = open("films.csv", 'w')
    gen = Generic(locales.EN)

    id_FK_studios_array = list(range(1, 1000 + 1))
    id_FK_directors_array = list(range(1, 1000 + 1))


    for i in range(1000):
        id_FK_studio = choice(id_FK_studios_array)
        id_FK_studios_array.remove(id_FK_studio)

        id_FK_directors = choice(id_FK_directors_array)
        id_FK_directors_array.remove(id_FK_studio)

        f.write(str(i + 1) + ','
         + str(id_FK_studio) + ','
         + str(randint(1, len(genre_list))) + ',' 
         + str(id_FK_directors) + ','
         + gen.text.word() + ','
         + film_creation_date_generate() + ','
         + str(randint(20000, 250000000)) + ','
         + str(randint(20000, 1000000000)) + ','
         + str(randint(150, 500)) + '\n')

    f.close()

'''
def generate_sites():
    f = open("sites.csv", 'w')  

    for i in range(len(film_sites_list)):
        f.write(str(i + 1) + ',' + film_sites_list[i] + '\n')

    f.close()  

def generate_films_sites():
    f = open("films_sites.csv", 'w')

    for i in range(len(film_sites_list)):
        id_FK_films_array = list(range(1, 1000 + 1))
        
        for _ in range(1000):
            id_FK_film = choice(id_FK_films_array)
            id_FK_films_array.remove(id_FK_film)
         
            f.write(str(id_FK_film) + ','
            + str(i + 1) + ',' 
            + str(randint(99, 499)) + '\n')

    f.close()
'''


def main():
    print("Generating...")

    generate_actors()
    generate_studios()
    generate_directors()
    generate_films()
    generate_genres()
    
    print("DONE")



if (__name__ == "__main__"):
    main()