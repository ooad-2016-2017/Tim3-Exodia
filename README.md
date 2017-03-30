<center>
<img src="http://vignette1.wikia.nocookie.net/yugioh/images/c/c0/ExodiatheForbiddenOne-TF04-JP-VG.jpg" alt="1">
<center>

# Tim3-Exodia

# Tema: Future Hotel

Članovi Tima:
1. Hamza Išerić
2. Enis Ahmetović
3. Mehmed Aljić

## Opis teme
Future Hotel je sistem koji automatizuje iznajmljivanje soba hotela, također olakšava upravljanje restoranom hotela i dodatnim aktivnostima u sklopu hotela. Svrha ovog sistema je znatno umanjivanje radne snage koja je potrebna za vođenje hotela. Recepcionarima je veoma teško voditi evidenciju o sobama koje su rezervisane i skloni su greškama pri tome. Future Hotel u potpunosti mijenja recepcionara. Klijenti, uz pomoć sistema, sami biraju tip sobe, broj dana koji žele ostati u hotelu i odmah plaćaju rezervaciju. Nakon rezervacije željene sobe, klijenti pristupaju svojim sobama korištenjem voice control-a. S ovim smo dostigli maksimalnu sigurnost i rad bez greške pri iznajmljivanju soba hotela. Još jedan veliki dio funkcionalnosti Future Hotela je vođenje restoranom u hotelu. Slično kao i kod rezervacije soba, klijenti koriste sistem da bi naručili jelo i platili za isto. Eliminisane su greške koje prave zaposlenici u restoranu tako što narudžbe direktno idu u kuhinju. Na svakom stolu se nalazi uređaj koji koristi naš sistem, tako da se precizno zna s kojeg stola je došla narudžba i kome se dostavlja jelo kada bude gotovo. Prednost Future Hotel sistema je fleksibilnost. Lahko je dodati neke druge aktivnosti koje su u sklopu hotela (bazen, sauna, tenis i sl.). Ukratko, najveći razlozi zašto biste koristili Future Hotel sistem je sigurnost, smanjenje radne snage, ušteda i objedinjavanje svih dijelova hotela u jedan kompaktan sistem.

## Procesi

**Rezervacija**


Klijent, pri ulasku u hotel, na recepciji nailazi na jedan od uređaja na kojima će biti instalirana naša aplikacija. Tada klijent bira tip sobe i broj noći. Pri odabiru se prikazuju samo dostupne sobe. Na kraju klijent provlači svoju karticu i u zavisnosti od stanja soba mu biva iznajmljena ili ne.

**Naručivanje jela**


Klijent kada sjedne za neki sto u restoranu, slično kao i kod rezervacije, koristi uređaj na kojem je instalirana aplikacija. Bira jelo i prikazana su samo ona jela za koja imaju namirnice na stanju. Na kraju klijent provlači svoju karticu, isto kao kod rezervacije soba, i u zavisnosti od stanja narudžba se odobri ili odbije. Svaki sto ima svoj uređaj koji ima svoj jedinstveni ID. Time se zna s kojeg je stola došla narudžba. Kada se jelo naruči odmah se iz baze skidaju količine namirnica koje su potrebne za to jelo. Narudžba ide direktno u kuhinju.

**Dostava jela**


Kuhar jelo pošalje time što unese šifru stola sa kojeg je došla narudžba.

**Menadžment ljudskih resursa**


Menadžer vodi evidenciju o zaposlenicima u bazi podataka. Također vodi evidenciju o namirnicama u kuhinji.

**Verifikacija glasa**


Klijent klikne na dugme, koje se nalazi kod svakih vrata, i kaže nešto. Uzorak se uzima i upoređuje sa uzorkom u bazi podaka. Nakon što istekne rezervacija sistem briše iz baze glas i šalje signal zaštitaru da provjeri stanje u sobi.


## Funkcionalnosti
- odabir jezika
- odabir tipa sobe
- rezervacija sobe
- otvaranje vrata glasom
- provjera isteka rezervacije
- jednostavno naručivanje jela
- jednostavna dostava do stola
- automatsko ažuriranje namirnica
- obavještenje zaštitara o isteku datuma rezervacije
- prihvatanje narudžbi u kuhinji
- naplaćivanje sobe
- naplaćivanje jela
- vođenje evidencije o zaposlenim
- vođenje evidencije o stanju namirnica u kuhinji

## Akteri
1. Klijent hotela je osoba koja želi da iznajmi sobu
2. Klijent restorana je osoba koja želi da jede u resoranu
3. Zaštitar je osoba koja provjerava da li su ljudi na vrijeme napustili hotel
4. Kuhar je osoba koja prima narudžbe, pravi jelo i dostavlja jelo
5. Menadžer vodi evidenciju o uposlenicima i stanju namirnica u kuhinji

