# API de Dados de Atracação de Navios - Porto de Santos

Esta é uma API desenvolvida em C# com .NET 8 que fornece um webhook para receber dados de atracação de navios do Porto de Santos e, em tempo real, transmite essas informações através de WebSockets para os consumidores que se conectarem.

## Funcionalidades

- **Webhook**: Recebe dados de atracação de navios do Porto de Santos.
- **WebSocket**: Envia os dados recebidos em tempo real para os clientes conectados.

## Requisitos

- .NET 8 SDK
- Visual Studio Code (opcional, para desenvolvimento)

## Instalação

1. **Clone o repositório**:

   ```bash
   git clone https://github.com/gabrielssantana/portohack-datilografos-backend.git
   cd portohack-datilografos-backend
   ```

2. **Restaurar pacotes NuGet**:

   ```bash
   dotnet restore
   ```

3. **Compilar o projeto**:

   ```bash
   dotnet build
   ```

## Executando a API

1. **Execute o projeto**:

   ```bash
   dotnet run
   ```

2. A API estará disponível em `http://localhost:5108` por padrão.

## Endpoints

### Webhook para Receber Dados

- **URL**: `http://localhost:5108/api/Webhook`
- **Método**: `POST`
- **Descrição**: Recebe dados de atracação de navios do Porto de Santos.

**Exemplo de Payload de requisição**:

```json
[
  {
    "id_viagem": "3038/2024",
    "id_lloyd_imo_dte": "",
    "id_lloyd_imo_aps": 9937335.0,
    "nome_navio_dte": "",
    "nome_navio_aps": "ONE PARANA",
    "data_aviso_chegada_dte": "",
    "data_aviso_chegada_aps": "14/09/2024",
    "hora_aviso_chegada_dte": "",
    "hora_aviso_chegada_aps": "",
    "nome_operador_dte": "",
    "flag_status": "Incorreto",
    "lista_corrigir": ["id_lloyd_imo", "nome_navio", "data_aviso_chegada"]
  }
]
```

### Websocket para Enviar Dados

- **URL**: `ws://localhost:5108/api/Websocket`
- **Descrição**: Envia dados de atracação de navios do Porto de Santos.

**Exemplo de Payload de resposta**:

```txt
[{\u0022id_viagem\u0022:\u00223038\\/2024\u0022,\u0022id_lloyd_imo_dte\u0022:\u0022\u0022,\u0022id_lloyd_imo_aps\u0022:9937335.0,\u0022nome_navio_dte\u0022:\u0022\u0022,\u0022nome_navio_aps\u0022:\u0022ONE PARANA\u0022,\u0022data_aviso_chegada_dte\u0022:\u0022\u0022,\u0022data_aviso_chegada_aps\u0022:\u002214\\/09\\/2024\u0022,\u0022hora_aviso_chegada_dte\u0022:\u0022\u0022,\u0022hora_aviso_chegada_aps\u0022:\u0022\u0022,\u0022nome_operador_dte\u0022:\u0022\u0022,\u0022flag_status\u0022:\u0022Incorreto\u0022,\u0022lista_corrigir\u0022:[\u0022id_lloyd_imo\u0022,\u0022nome_navio\u0022,\u0022data_aviso_chegada\u0022]}]
```
