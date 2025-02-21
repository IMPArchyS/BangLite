# BANG Lite

Vašou úlohou je naprogramovať zjednodušenú kartovú hru BANG ako **konzolovú** hru v jazyku Java.

## Úvod do hry

Hráči sa nachádzajú na divokom západe, a kedže sa jedná o zjednodušenú verziu hry, tak bojujú všetci proti sebe. V našej zjednodušenej verzií hry nemáme ani postavy, ani zbrane a veľa dalších kariet z pôvodnej hry.

## Cieľ hry

Zostať posledný nažive.

## Karty

V našej verzií hry sa nachádzajú dva typy kariet, a to **Modré** a **Hnedé** karty.

#### Modré karty

Modré karty po zahratí ležia pred hráčom, a ich efekt je trvajúci, až do ich odstránenia.

* 2x Barrel
* 1x Dynamit
* 3x Väzenie

#### Hnedé karty

Hnedé karty majú okamžitý efekt a po zahratí sa hneď odhadzujú do odhadzovacieho balíčka.

* 30x Bang
* 15x Vedľa
* 8x Pivo
* 6x Cat Balou
* 4x Dostavník
* 2x Indiáni

Efekty jednotlivých kariet sú popísané nižšie.

## Príprava hry

Hru môže hrať 2-4 hráčov. Každý hráč dostane na začiatku 4 karty z balíčka a začína so 4 životmi. Horný počet životov obmedzený nie je.

## Priebeh hry

Hráči hrajú postupne v rade za sebou. Ťah každého hráča sa delí na 3 časti, a to:
* 1. Tahanie kariet - na začiatku svojho ťahu si daný hráč potiahne 2 karty z balíčka. Pokiaľ má pred sebou nejakú efektovú kartu (Väzenie, Dynamit) vykonáva sa najskôr ich efekt.
* 2. Zahranie kariet - hráč môže zahrať ľubovolný počet kariet počas svojho ťahu, tak isto ale nemusí zahrať žiadnu. Počas tohto ťahu však musí byť splnené pravidlo, že pred hráčom môže ležať len jedna kópia každej karty (Príklad: Ak už má hráč pred sebou Barrel, nemôže pred seba vyložiť ďalší).
* 3. Odhadzovanie prebytočných kariet - hráč na konci svojho kola môže mať len toľko kariet v ruke, koľko má životov.

## Zabitie protivníka

Ak niektorí z hráčov zomrie, musí vrátiť všetky karty z ruky a zo stola pred sebou naspať do odhadzovacieho balíčka. Ak hráč zomrie zavinením iného hráča, môžte vymyslieť odmenu danému hráčovi za zabitie (Napríklad že si potiahne 2 karty. Táto úloha je nepovinná).

## Vysvetlenie jednotlivých kariet

#### Bang a Vedľa

Karty Bang predstavujú hlavný spôsob, ako znížiť počet životov svojim protihráčom. V našej zjednodušenej verzií hry môžete počas svojho ťahu týchto kariet zahrať neobmedzený počet.

Pokiaľ ste cielom karty Bang, automaticky zahráte kartu vedľa, pokiaľ žiadnu nemáte, strácate život. Pokiaľ stratíte všetky životy, vypadávate z hry.

Príklad ťahu v našej zjednodušenej verzií hry: Hráč A zahrá kartu Bang na Hráča B, Hráč B automaticky skontroluje či má kartu vedľa, pokiaľ takú kartu má, karta sa automaticky zahrá, pokiaľ takú kartu nemá, prichádza o život.

#### Barrel

Barrel je karta, ktorá vám dáva šancu skryť sa pred útokom karty BANG. Šanca na skytie je 1 ku 4.

Príklad ťahu: Niektorí z hráčov na vás vystrelí kartou BANG, a vy máte pred sebou Barrel, môžete skontrolovať jeho efekt, a môže sa vám podariť sa vyhnúť výstrelu, pokiaľ sa vám podarí sa mu vyhnúť, dalšie vyhodenie karty vedľa nie je potrebné, ak sa mu nevyhnete, hra ďalej automaticky kontroluje či máte kartu vedľa.

#### Pivo

Karta pivo dovoľuje hráčovi pridať si jeden život. Efekt karty sa dá použiť iba na aktuálne hrajúceho hráča.

#### Dostavník

Pomocou karty dostavník si hráč môže potiahnuť dve karty z balíčka.

#### Indiáni

Zahraním karty Indiáni spôsobíte útok indiánov na všetkých hráčov (okrem hráča ktorý ju zahral). Každý z hráčou odhodí kartu *Bang* (ak ju má) alebo príde o jeden život.

#### Cat Balou

Zahraním tejto karty môžete odhodiť kartu protivníkovi, či už zo stola alebo z ruky.

Príklad zahrania karty: Hráč A zahrá kartu Cat Balou na Hráča B, hra mu ponúkne či chce odhodiť kartu z ruky alebo zo stola, a po danom výbere sa Hráčovi B automaticky vyhodí náhodne zvolená karta. Pokiaľ Hráč B nemá žiadnu kartu, Hráčovi A sa ukáže hláška že túto kartu nemôže momentálne na daného hráča zahrať.

#### Väzenie

Túto kartu dávate pred ľubovoného iného hráča, a danou kartou ho uväzníte. Pokiaľ má hráč pred začiatkom svojho kola pred sebou kartu Väzenie, musí skontrolovať jej efekt, či sa mu podarí z neho ujsť alebo nie. Šanca na újdenie z väzenia je 1 ku 4. Ak sa mu z väzenia nepodarí ujsť - vynecháva dané kolo, pokiaľ z neho ujde, pokračuje vo svojom ťahu. V oboch prípadoch sa karta po kontrole jej efektu vyhadzuje do odhadzovacieho balíčka.

#### Dynamit

Túto kartu pri zahratí vykladáte pred seba. Efekt karty Dynamit sa kontroluje vždy na začiatku kola, pokiaľ dynamit vybuchne pred vami, strácate 3 životy a karta sa odhadzuje do balíčka. Pokiaľ vám dynamit nevybuchne, karta sa posúva hráčovi, ktorý hral pred vami (Dynamit sa posúva opačným smerom, akým prebieha hra). Šanca na vybuchnutie dynamitu je 1 ku 8;

Pokiaľ by nastala situácia, že hráč má na začiatku kola pred sebou aj kartu Väzenie aj Dynamit, kontroluje sa najskôr efekt karty Dynamit a až potom Väzenie.

## Zdroje (pre lepšie pochopenie zadania)
* [Pravidlá pôvodnej hry](https://eshop.albi.cz/data/files/products/24327/1603711687-bang-pravidla-zakladni-hry.pdf)
