using System.Diagnostics;
using FestaEcia;
using POOCasamentosECia;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            int opcao = 0;
            TextoMenu();
            Console.WriteLine("Escolha uma das opções acima: ");
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                Console.ReadKey();
            }
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    MostrarDatasFestas();
                    Console.WriteLine("Aperte qualquer tecla para voltar. ");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Festas();
                    break;
                case 3:
                    return;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;
            }

        }
    }

    #region Calendário
    public static void MostrarDatasFestas()
    {
        string[] InformacaoFesta;
        string linha;
        StreamReader ler = null;
        try
        {
            ler = new StreamReader("./festas/festas.txt", true);

            linha = ler.ReadLine();
            linha = ler.ReadLine();
            linha = ler.ReadLine();
            linha = ler.ReadLine();
            linha = ler.ReadLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ CALENDÁRIO ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            if ((linha = ler.ReadLine()) == null)
            {
                Console.WriteLine();
                Console.WriteLine("                    NENHUMA FESTA FOI CADASTRADA.");
                Console.WriteLine();
            }
            while (linha != null)
            {
                InformacaoFesta = linha.Split(" ");
                Console.WriteLine("Data: " + InformacaoFesta[0] + ", Festa: " + InformacaoFesta[1] + ", Espaço ocupado: " + InformacaoFesta[3]);
                linha = ler.ReadLine();
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
        finally { ler.Close(); }
    }
    #endregion

    #region FunçõesTextos
    public static void TextoMenu()
    {
        Console.WriteLine("~~~~~~~~~~~~~ MENU ~~~~~~~~~~~~~");
        Console.WriteLine("1 - Vizualizar o calendário.");
        Console.WriteLine("2 - Adicionar festa.");
        Console.WriteLine("3 - Sair");
    }
    public static void TextoEscolhaFesta()
    {
        Console.WriteLine("~~~~~~~~~~~~~ Escolha uma festa ~~~~~~~~~~~~~");
        Console.WriteLine("1 - Casamento.");
        Console.WriteLine("2 - Formatura.");
        Console.WriteLine("3 - Festa de empresa.");
        Console.WriteLine("4 - Festa de aniversário.");
        Console.WriteLine("5 - Livre");
    }
    public static void TextoQuantidadeConvidados()
    {
        Console.WriteLine("~~~~~~~~~ Capacidade de convidados ~~~~~~~~~");
        Console.WriteLine("          Espaço       Capacidade");
        Console.WriteLine("          A, B, C, D  100 pessoas");
        Console.WriteLine("          E, F        200 pessoas");
        Console.WriteLine("          G            50 pessoas");
        Console.WriteLine("          H           500 pessoas");
    }
    public static void TextoBebidas(TipoCerimonia tipoCerimonia)
    {
        Console.WriteLine("~~~~~~~~~~~ Bebidas disponíveis ~~~~~~~~~~~");
        Console.WriteLine("Item                       Preço unitário");
        Console.WriteLine("1 - Água sem gás (1,5l)         R$   5,00");
        Console.WriteLine("2 - Suco (1l)                   R$   7,00");
        Console.WriteLine("3 - Refrigerante (2l)           R$   8,00");
        Console.WriteLine("4 - Cerveja comum (600ml)       R$  20,00");
        Console.WriteLine("5 - Espumante nacional (750ml)  R$  80,00");
        if (tipoCerimonia == TipoCerimonia.PREMIER)
        {
            Console.WriteLine("6 - Cerveja artesanal (600ml)   R$  30,00");
            Console.WriteLine("7 - Espumante importado (750ml) R$ 140,00");
        }
        Console.WriteLine("8 - Sair");
    }
    public static void TextoTipoCerimonia()
    {
        Console.WriteLine("~~~~~~~~~ Tipo da Festa ~~~~~~~~~");
        Console.WriteLine("1 - Standard");
        Console.WriteLine("2 - Luxo");
        Console.WriteLine("3 - Premier");
    }
    #endregion

    #region FunçõesVerificadoras
    private static bool VerificaSextaOuSabado(DateTime data)
    {
        DayOfWeek dia = data.DayOfWeek;
        return dia == DayOfWeek.Friday || dia == DayOfWeek.Saturday;
    }
    private static bool PrazoMinimo30Dias(DateTime data)
    {
        DateTime hoje = DateTime.Today;
        int diferencaDias = (data - hoje).Days;
        return diferencaDias >= 30;
    }
    private static bool VerificaEspacoDisponivel(DateTime data, ref TipoEspaco tipoEspaco, int quantidadeConvidados)
    {
        string[] InformacaoFesta;
        string linha;
        string datatxt = data.ToString("dd/MM/yyyy");
        string tipoEspacotxt = tipoEspaco.ToString();

        TipoEspaco copiaTipoEspaco = tipoEspaco;

        StreamReader ler = null;
        try
        {
            ler = new StreamReader("./festas/festas.txt", true);
            linha = ler.ReadLine();
            linha = ler.ReadLine();
            linha = ler.ReadLine();
            linha = ler.ReadLine();
            linha = ler.ReadLine();

            if (quantidadeConvidados > 50 && quantidadeConvidados <= 200)
            {
                if (quantidadeConvidados > 50 && quantidadeConvidados <= 100)
                {
                    int contador = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        while (linha != null)
                        {
                            InformacaoFesta = linha.Split(" ");
                            if (datatxt == InformacaoFesta[0] && tipoEspacotxt == InformacaoFesta[3])
                            {
                                ++contador;
                                copiaTipoEspaco = MudarEspaco(copiaTipoEspaco);
                                tipoEspacotxt = copiaTipoEspaco.ToString();
                                break;
                            }
                            linha = ler.ReadLine();
                        }
                    }
                    if (contador == 3)
                    {
                        return false;
                    }
                }
                else
                {
                    int contador = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        while (linha != null)
                        {
                            InformacaoFesta = linha.Split(" ");
                            if (datatxt == InformacaoFesta[0] && tipoEspacotxt == InformacaoFesta[3])
                            {
                                ++contador;
                                copiaTipoEspaco = MudarEspaco(copiaTipoEspaco);
                                tipoEspacotxt = copiaTipoEspaco.ToString();
                                break;
                            }
                            linha = ler.ReadLine();
                        }
                    }
                    if (contador == 2)
                    {
                        return false;
                    }
                }
            }
            else
            {
                while (linha != null)
                {
                    InformacaoFesta = linha.Split(" ");
                    if (datatxt == InformacaoFesta[0] && tipoEspacotxt == InformacaoFesta[3])
                    {
                        return false;
                    }
                    linha = ler.ReadLine();
                }
            }
        }
        catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
        finally { ler.Close(); }

        tipoEspaco = copiaTipoEspaco;
        return true;
    }
    #endregion

    #region FunçõesRetornaValor
    public static TipoEspaco DefinirEspaco(int quantidadeConvidados)
    {
        if (quantidadeConvidados >= 0 && quantidadeConvidados <= 50)
        {
            return TipoEspaco.ESPACO_G;
        }
        else if (quantidadeConvidados > 50 && quantidadeConvidados <= 100)
        {
            return TipoEspaco.ESPACO_A;
        }
        else if (quantidadeConvidados > 100 && quantidadeConvidados <= 200)
        {
            return TipoEspaco.ESPACO_E;
        }
        else
        {
            return TipoEspaco.ESPACO_H;
        }
    }

    public static TipoEspaco MudarEspaco(TipoEspaco tipoEspaco)
    {
        if (tipoEspaco == TipoEspaco.ESPACO_A)
        {
            return TipoEspaco.ESPACO_B;
        }
        else if (tipoEspaco == TipoEspaco.ESPACO_B)
        {
            return TipoEspaco.ESPACO_C;
        }
        else if (tipoEspaco == TipoEspaco.ESPACO_C)
        {
            return TipoEspaco.ESPACO_D;
        }
        else
        {
            return TipoEspaco.ESPACO_F;
        }
    }
    #endregion

    #region Festas
    public static void Festas()
    {
        bool verificador;

        #region TipoFesta
        verificador = true;
        TipoFesta tipoFesta = TipoFesta.LIVRE;
        while (verificador)
        {
            Console.Clear();
            int opcao = 0;
            TextoEscolhaFesta();
            Console.WriteLine("Escolha uma das opções acima: ");
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch { }
            switch (opcao)
            {
                case 1:
                    tipoFesta = TipoFesta.CASAMENTO;
                    verificador = false;
                    break;
                case 2:
                    tipoFesta = TipoFesta.FORMATURA;
                    verificador = false;
                    break;
                case 3:
                    tipoFesta = TipoFesta.FESTA_DE_EMPRESA;
                    verificador = false;
                    break;
                case 4:
                    tipoFesta = TipoFesta.FESTA_DE_ANIVERSARIO;
                    verificador = false;
                    break;
                case 5:
                    tipoFesta = TipoFesta.LIVRE;
                    verificador = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }
        #endregion

        #region QuantidadeConvidados
        verificador = true;
        int quantidadeConvidados = 0;
        while (verificador)
        {
            Console.Clear();
            TextoQuantidadeConvidados();
            Console.WriteLine("Digite a quantidade de convidados: ");
            try
            {
                quantidadeConvidados = int.Parse(Console.ReadLine());
                if (quantidadeConvidados < 0)
                {
                    throw new ValorNegativoException("Valor negativo inválido.");
                }
                if (quantidadeConvidados > 500)
                {
                    throw new ValorConvidadosSuperiorPermitidoException("Quantidade de convidados superior ao permitido");
                }
                else { verificador = false; }
            }
            catch (ValorNegativoException vne)
            {
                Console.Clear();
                Console.WriteLine(vne.Message);
                Console.WriteLine("Aperte qualquer tecla para continuar.");
                Console.ReadKey();
            }
            catch (ValorConvidadosSuperiorPermitidoException vcspe)
            {
                Console.Clear();
                Console.WriteLine(vcspe.Message);
                Console.WriteLine("Aperte qualquer tecla para continuar.");
                Console.ReadKey();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                Console.ReadKey();
            }
        }
        #endregion

        #region TipoEspaco
        TipoEspaco tipoEspaco = DefinirEspaco(quantidadeConvidados);
        #endregion

        #region Data
        verificador = true;
        DateTime data = DateTime.Today;
        while (verificador)
        {
            Console.Clear();
            Console.WriteLine("Digite uma data (formato 1/01/0001): ");
            try
            {
                string input = Console.ReadLine();
                data = DateTime.ParseExact(input, "dd/MM/yyyy", null);

                if (VerificaSextaOuSabado(data))
                {
                    if (PrazoMinimo30Dias(data))
                        if (VerificaEspacoDisponivel(data, ref tipoEspaco, quantidadeConvidados))
                        {
                            verificador = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Não possuí espaço disponível, escolha outra data.");
                            Console.WriteLine("Aperte qualquer tecla para continuar.");
                            Console.ReadKey();
                        }
                    else
                    {
                        throw new VerificaPrazoMinimo30DiasException("A data deve ter um prazo mínimo de 30 dias.");
                    }
                }
                else
                {
                    throw new VerificaSextaSabadoException("A data deve dar em uma Sexta ou Sabado.");
                }
            }
            catch (VerificaSextaSabadoException vsse)
            {
                Console.Clear();
                Console.WriteLine(vsse.Message);
                Console.WriteLine("Aperte qualquer tecla para continuar.");
                Console.ReadKey();
            }
            catch (VerificaPrazoMinimo30DiasException vpm30d)
            {
                Console.Clear();
                Console.WriteLine(vpm30d.Message);
                Console.WriteLine("Aperte qualquer tecla para continuar.");
                Console.ReadKey();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                Console.ReadKey();
            }
        }
        #endregion

        #region FestaLivre
        if (tipoFesta == TipoFesta.LIVRE)
        {
            Console.Clear();
            Livre livre = new Livre(new Espaco(TipoEspaco.ESPACO_A), TipoFesta.LIVRE, 100, data);
            livre.InformacaoFesta();
            livre.Salvartxt();
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadKey();
            return;
        }
        #endregion


        #region TipoCerimonia
        verificador = true;
        TipoCerimonia tipoCerimonia = TipoCerimonia.LUXO;
        if (tipoFesta != TipoFesta.FESTA_DE_ANIVERSARIO)
        {
            while (verificador)
            {
                Console.Clear();
                TextoTipoCerimonia();
                Console.WriteLine("Digite uma das opções acima:");
                int opcao = 0;
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao < 0)
                    {
                        throw new ValorNegativoException("Valor negativo inválido.");
                    }
                }
                catch (ValorNegativoException vne)
                {
                    Console.Clear();
                    Console.WriteLine(vne.Message);
                    Console.WriteLine("Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                    Console.ReadKey();
                }

                switch (opcao)
                {
                    case 1:
                        tipoCerimonia = TipoCerimonia.STANDARD;
                        verificador = false;
                        break;
                    case 2:
                        tipoCerimonia = TipoCerimonia.LUXO;
                        verificador = false;
                        break;
                    case 3:
                        tipoCerimonia = TipoCerimonia.PREMIER;
                        verificador = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        #endregion

        #region Buffet

        #region BuffetComida
        IComida comida;
        if (tipoCerimonia == TipoCerimonia.STANDARD)
        {
            comida = new ComidaStandard(quantidadeConvidados);
        }
        else if (tipoCerimonia == TipoCerimonia.LUXO)
        {
            comida = new ComidaLuxo(quantidadeConvidados);
        }
        else
        {
            comida = new ComidaPremier(quantidadeConvidados);
        }
        #endregion

        #region BuffetBebida
        verificador = true;
        Buffet buffet = null;
        List<Bebida> bebidas = new List<Bebida>();
        int quantidadeBebida = 0;
        while (verificador)
        {
            Console.Clear();
            TextoBebidas(tipoCerimonia);
            Console.WriteLine("Digite uma das opções acima:");
            int opcao = 0;
            try
            {
                opcao = int.Parse(Console.ReadLine());
                if (opcao != 8)
                {
                    Console.WriteLine("Digite a quantidade de bebidas: ");
                    quantidadeBebida = int.Parse(Console.ReadLine());
                }
                if (opcao < 0 || quantidadeBebida < 0)
                {
                    throw new ValorNegativoException("Valor negativo inválido.");
                }
            }
            catch (ValorNegativoException vne)
            {
                Console.Clear();
                Console.WriteLine(vne.Message);
                Console.WriteLine("Aperte qualquer tecla para continuar.");
                Console.ReadKey();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                Console.ReadKey();
            }

            if (tipoCerimonia != TipoCerimonia.PREMIER)
            {
                switch (opcao)
                {
                    case 1:
                        bebidas.Add(new Bebida(TipoBebida.AGUA_SEM_GAS, quantidadeBebida));
                        break;
                    case 2:
                        bebidas.Add(new Bebida(TipoBebida.SUCO, quantidadeBebida));
                        break;
                    case 3:
                        bebidas.Add(new Bebida(TipoBebida.REFRIGERANTE, quantidadeBebida));
                        break;
                    case 4:
                        bebidas.Add(new Bebida(TipoBebida.CERVEJA_COMUM, quantidadeBebida));
                        break;
                    case 5:
                        bebidas.Add(new Bebida(TipoBebida.ESPUMANTE_NACIONAL, quantidadeBebida));
                        break;
                    case 8:
                        buffet = new Buffet(bebidas, comida);
                        verificador = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                switch (opcao)
                {
                    case 1:
                        bebidas.Add(new Bebida(TipoBebida.AGUA_SEM_GAS, quantidadeBebida));
                        break;
                    case 2:
                        bebidas.Add(new Bebida(TipoBebida.SUCO, quantidadeBebida));
                        break;
                    case 3:
                        bebidas.Add(new Bebida(TipoBebida.REFRIGERANTE, quantidadeBebida));
                        break;
                    case 4:
                        bebidas.Add(new Bebida(TipoBebida.CERVEJA_COMUM, quantidadeBebida));
                        break;
                    case 5:
                        bebidas.Add(new Bebida(TipoBebida.ESPUMANTE_NACIONAL, quantidadeBebida));
                        break;
                    case 6:
                        bebidas.Add(new Bebida(TipoBebida.CERVEJA_ARTESANAL, quantidadeBebida));
                        break;
                    case 7:
                        bebidas.Add(new Bebida(TipoBebida.ESPUMANTE_IMPORTADO, quantidadeBebida));
                        break;
                    case 8:
                        buffet = new Buffet(bebidas, comida);
                        verificador = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Valor inválido! Aperte qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        #endregion
        #endregion

        #region FestaCasamento
        if (tipoFesta == TipoFesta.CASAMENTO)
        {
            Console.Clear();
            Casamento casamento = new Casamento(new Espaco(tipoEspaco), tipoCerimonia, quantidadeConvidados, tipoFesta, new Musica(tipoCerimonia), buffet, data, new Bolo(tipoCerimonia), new Decoracao(tipoCerimonia), new ItensMesa(tipoCerimonia));
            casamento.InformacaoFesta();
            casamento.Salvartxt();
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadKey();
            return;
        }
        #endregion
        #region FestaFormatura
        else if (tipoFesta == TipoFesta.FORMATURA)
        {
            Console.Clear();
            Formatura formatura = new Formatura(new Espaco(tipoEspaco), tipoCerimonia, quantidadeConvidados, tipoFesta, new Musica(tipoCerimonia), buffet, data, new Decoracao(tipoCerimonia), new ItensMesa(tipoCerimonia));
            formatura.InformacaoFesta();
            formatura.Salvartxt();
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadKey();
        }
        #endregion
        #region FestaEmpresa
        else if (tipoFesta == TipoFesta.FESTA_DE_EMPRESA)
        {
            Console.Clear();
            FestaEmpresa festaEmpresa = new FestaEmpresa(new Espaco(tipoEspaco), tipoCerimonia, quantidadeConvidados, tipoFesta, new Musica(tipoCerimonia), buffet, data);
            festaEmpresa.InformacaoFesta();
            festaEmpresa.Salvartxt();
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadKey();
        }
        #endregion
        #region FestaAniversário
        if (tipoFesta == TipoFesta.FESTA_DE_ANIVERSARIO)
        {
            Console.Clear();
            FestaAniversario festaAniversario = new FestaAniversario(new Espaco(tipoEspaco), quantidadeConvidados, tipoFesta, new Musica(TipoCerimonia.STANDARD), buffet, data, new Bolo(TipoCerimonia.STANDARD), new Decoracao(TipoCerimonia.STANDARD), new ItensMesa(TipoCerimonia.STANDARD));
            festaAniversario.InformacaoFesta();
            festaAniversario.Salvartxt();
            Console.WriteLine("Aperte qualquer tecla para continuar.");
            Console.ReadKey();
            return;
        }
        #endregion
    }
    #endregion
}
