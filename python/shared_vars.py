import pandas as pd

teste = pd.read_csv('https://raw.githubusercontent.com/magemongo/ContentLovers/master/publishers_estados.csv', encoding='UTF-8', error_bad_lines=False, sep=';')
teste.drop_duplicates(subset='Double' ,keep='first', inplace=True, ignore_index=True)
links = []
for link in teste.Link:
  links.append(link)
i = 0