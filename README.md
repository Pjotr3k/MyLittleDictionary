# MyLittleDictionary
By Piotr Węgrzyniak

This project is a dictionary.

Installation:
 - import database (./MyLittleDic/my_little_dict.sql)
 - compile the project

The Web App functionality
  - displaying entries (with information including the meaning, grammatical forms of given word as well of the language of the entry)
  - adding new entries (the "Add Entries" tab at menu bar)
  - adding forms to exisitng entries (the "edit forms" button below the table of forms of each entry)
  
The database include following tables:
  - entries:      collects entries, being a connector between words with their meanings
  - definitions:  collets definitions of words. This table doesn't use a foreing key, this way you can use a single definition for many entries which makes implementing functions like finding translations and finding synonyms easier.
  - languages, parts_of_speech: collects languages and parts of speech, respectively
  - forms:        collects possible word forms (like tense or grammatical case) to use with respective language and part of speech (both as foreign key)
  - words:        collects words in various grammatical forms for entries
  - entry-def-connect: connects entries and definitions in many-to-many relation
  
 Planned features
  - search bar for entries
  - displaying translation of particular words in different languages
  - displaying synonyms
 
  

