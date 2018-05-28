get-all-ustanova.php - vraca sve ustanove

get-ustanova-stanje.php?id_ustanove=XXX - daje stanje ustanove za trenutni dan

update-stanje-poslednji.php?id_ustanove=XXX&poslednji_uzeti=YYY
# Update tabelu stanje, prosledjuje se id ustanove i poslednji_uzeti za trenutni dan
# Kreira novi red u tabeli ukoliko se salje prvi put upit za trenutni dan

update-stanje-poslednji.php?id_ustanove=XXX&trenutno_stanje=YYY
# Update tabelu stanje, prosledjuje se id ustanove i trenutno_stanje za trenutni dan
# Kreira novi red u tabeli ukoliko se salje prvi put upit za trenutni dan