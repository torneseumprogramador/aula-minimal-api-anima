curl -X 'POST' \
  'http://localhost:5170/cadastro' \
  -H 'accept: application/json' \
  -H 'Content-Type: application/json' \
  -d '{
  "item": "pão",
  "descricao": "de sal"
}'
