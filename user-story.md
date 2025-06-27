Como PO quero 
Cadastrar um novo fornecedor no sistema através de uma API (endpoint POST /api/suppliers), informando dados como razão social, CNPJ, e-mail e telefone de contato.

para que:
O fornecedor possa ser incluído na base de dados do sistema, viabilizando o agendamento de serviços, emissão de notas, e controle de relacionamento comercial.

📋 Critérios de Aceitação:
 O endpoint deve aceitar um payload com os seguintes campos obrigatórios:
companyName: string não vazia
cnpj: string válida (com validação)
email: string válida
phoneNumber: string (opcional)
O sistema deve validar o CNPJ e o e-mail como ValueObjects do domínio.
Caso o CNPJ já esteja cadastrado, deve retornar HTTP 409 Conflict.
O retorno deve ser HTTP 201 Created com os dados do fornecedor criado.
O ID do fornecedor deve ser retornado na resposta.
A operação deve estar coberta por testes automatizados de unidade e integração.