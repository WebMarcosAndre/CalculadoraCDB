namespace Investment.Domain.Message
{
    public static class ValidationMessage
    {
        public static string TermInMonthGreaterThanZero = "O período para o cálculo deve ser maior que 0 (zero).";

        public static string InvalidInput = "Não foi possível calcular o imposto, verifique os dados informados.";
        public static string AmountCannotBeNegative = "Valor investido não pode ser negativo.";
    }
}
