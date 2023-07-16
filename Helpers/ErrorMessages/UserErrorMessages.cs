namespace adstaskhub_api.Helpers.ErrorMessages
{
    public class UserErrorMessages
    {
        public const string UserNotFound = "Usuário não encontrado.";
        public const string InvalidEmailOrPassword = "Email ou senha inválidos.";
        public const string UserAlreadyExists = "Já existe um usuário com este email.";
        public const string InvalidUserId = "ID do usuário inválido.";
        public const string UserUpdateFailed = "Falha ao atualizar o usuário.";
        public const string UserNotApproved = "Usuário ainda não aprovado, aguarde aprovação ou entre em contato conosco!";
        public const string UserCreationDataNull = "Os dados de criação do usuário não podem ser nulos.";
    }
}
