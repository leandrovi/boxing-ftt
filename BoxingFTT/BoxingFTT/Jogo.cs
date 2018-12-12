using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Projeto N2 - BoxingFTT
//Desenvolvido por: Leandro Fernandes Vieira
//RA: 082170013
//Curso: EC2
//Disciplina: Algoritmos II
//Data: Junho/2018

namespace BoxingFTT
{
    public partial class Jogo : Form
    {
        //Cronometro regressivo que servirá para encerrar o jogo e contar no score
        Stopwatch cronometro = new Stopwatch();
        TimeSpan contagemRegressiva = new TimeSpan();

        //Vetor que define a dificuldade do jogo
        string[] dificuldadeJogo = new string[3] {"facil", "medio", "dificil"};

        //Variáveis booleanas que permitem o movimento do jogador
        bool andarPraDireita;
        bool andarPraEsquerda;

        //Inteiro que define o quanto o jogador se desloca
        int velocidadeJogador = 5;

        //Validador do movimento de bloqueio do jogador
        bool bloquearAtaque = false;

        //Lista de ataques da máquina
        List<string> ataquesMaquina = new List<string> { "left", "right", "block" };

        //Classe randomica usada para gerar números aleatórios
        Random nAleatorio = new Random();

        //Variável da velocidade da máquina
        int velocidadeMaquina = 5;

        //Inteiro que define o quanto a maquina se desloca
        int i = 0;

        //Validador do movimento de bloqueio da máquina
        bool bloqueioMaquina;

        //Variáveis para atualização da vida
        int vidaJogador = 100; //Vida total do jogador
        int vidaMaquina = 100; //Vida total da máquina

        //Inteiro que define o score do jogador
        int score = 0;

        public Jogo()
        {
            InitializeComponent();
            //Buffer para diminuir o flicker
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            //Inicializar com a barra de progresso da vida 100% cheia
            pgbVidaJogador.ForeColor = Color.FromArgb(100, 71, 255, 78);
            pgbVidaMaquina.ForeColor = Color.FromArgb(100, 71, 255, 78);

            //Inicia o cronometro da contagem regressiva
            timerCronometro.Start();
            cronometro.Restart();
        }

        
        /// <summary>
        /// Este evento tem por objetivo controlar a atualização do
        /// cronometro na tela, além de atribuir pontos ao score.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eventoCronometro(object sender, EventArgs e)
        {

            var tempoDeJogo = new TimeSpan(0, 0, 0, 60, 0);
            contagemRegressiva = tempoDeJogo - cronometro.Elapsed;
            lblCronometro.Text = String.Format("{0:00}:{1:00}:{2:00}",
                contagemRegressiva.Minutes, contagemRegressiva.Seconds, contagemRegressiva.Milliseconds / 10);                                      
        }

        /// <summary>
        /// Este evento tem por objetivo mover a máquina no modo "Humano
        /// versus Máquina", lado a lado, a partir do jogador. Rodará a 
        /// cada 20 milisegundos, resultando em um rápido grau de frames.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eventoMovimentoMaquina(object sender, EventArgs e)
        {
            //Evento que automatizará o movimento de esquerda e direita da máquina
            //Ao fazer esse link do movimento com a velocidade, a máquina começará a se movimentar.
            picMaquina.Left += velocidadeMaquina; //Aumento da distância à esquerda da tela

            //Se a vida do jogador for maior que 1
            if (vidaJogador > 1)
            {
                //Então a barra de progresso do jogador receberá o valor da vida
                pgbVidaJogador.Value = Convert.ToInt32(vidaJogador);
            }

            //Se a vida da máquina for maior que 1
            if (vidaMaquina > 1)
            {
                //Então a barra de progresso da máquina receberá o valor da vida
                pgbVidaMaquina.Value = Convert.ToInt32(vidaMaquina);
            }

            //A maquina se movimentará de um lado ao outro, mas não tão longe do jogador.
            //Para tanto, ela terá um limite de movimento entre 220px e 555px da tela.
            //Ao atingir qualquer um desses dois valores, a velocidade terá o sinal invertido,
            //e ele começará a ir em direção ao sentido oposto, de volta ao jogador.
            //Logo, se a posição da máquina ultrapassar o valor de 555px
            if (picMaquina.Left > 700)
            {
                //Ela se movimentará para a esquerda
                velocidadeMaquina = -3;
            }

            //Se a máquina estiver em uma posição menor que 220px
            if (picMaquina.Left < 100)
            {
                //Ela se movimentará para a direita
                velocidadeMaquina = 5;
            }

            //Se a vida da máquina for menor que 1
            if (vidaMaquina < 1)
            {
                //O jogador vence e a máquina perde
                //Então, os três timers e o cronometro param de rodar
                timerMaquina.Stop();
                movimentoMaquina.Stop();
                movimentoJogador.Stop();
                cronometro.Stop();
                timerCronometro.Stop();

                //É mostrada a mensagem de vitória do jogador
                MessageBox.Show("Jogador ganhou! Clique em ok para continuar ou cancelar para voltar ao menu principal:");

                //O reset do game é rodado
                resetarJogo();
            }

            //Se a vida do jogador for menor que 1
            if (vidaJogador < 1)
            {
                //O jogador perde e a máquina vence
                //Então, os quatro timers e o cronometro param de rodar
                timerMaquina.Stop();
                movimentoMaquina.Stop();
                movimentoJogador.Stop();
                cronometro.Stop();
                timerCronometro.Stop();

                //É mostrada a mensagem de vitória da máquina
                MessageBox.Show("Maquina ganhou! Clique em ok para continuar ou cancelar para voltar ao menu principal:");

                //O reset do game é rodado
                resetarJogo();
            }

            //Se o cronometro parar antes que alguem vença
            if (contagemRegressiva.TotalMilliseconds < 0)
            {
                lblCronometro.Text = "00:00:00";
                //Então, os quatro timers e o cronometro param de rodar
                timerMaquina.Stop();
                movimentoMaquina.Stop();
                movimentoJogador.Stop();
                cronometro.Stop();
                timerCronometro.Stop();

                //É mostrada a mensagem de tempo esgotado
                MessageBox.Show("Tempo esgotado, máquina ganhou! Clique em ok para continuar ou cancelar para voltar ao menu principal:");

                //O reset do game é rodado
                resetarJogo();
            }
        }

        /// <summary>
        /// Este evento tem por objetivo realizar os socos e bloqueios
        /// do computador no modo de jogo "Humano versus Máquina".
        /// Deverá rodar a cada 1000 milisecundos / 1 segundo. Resultará 
        /// em um movimento dinâmico para a máquina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eventoSocoMaquina(object sender, EventArgs e)
        {
            //Etapa de gerar um número randomico e armazenar na variável "i"
            //O número aleatório deve ser entre 0 e o numero de ataques na lista de ataques: <string> ataquesMaquina
            i = nAleatorio.Next(0, ataquesMaquina.Count);

            //Cláusula Switch para checar qual movimento a máquina está efetuando
            switch (ataquesMaquina[i].ToString())
            {
                //Se o ataque for esquerda
                case "left":

                    //Então a imagem da maquina mudará
                    picMaquina.Image = Properties.Resources.enemy_punch1;

                    //Ainda, se o jogador e a máquina encostarem e o bloqueio do jogador for falso
                    if (picMaquina.Bounds.IntersectsWith(picJogador.Bounds) && !bloquearAtaque)
                    {
                        //Então a vida do jogador será reduzida
                        vidaJogador -= 10;
                    }

                    //O bloqueio da maquina é falso, pois está atacando
                    bloqueioMaquina = false;
                    break;

                //Se o ataque for direita
                case "right":

                    //Então a imagem da maquina mudará
                    picMaquina.Image = Properties.Resources.enemy_punch2;

                    //Ainda, se o jogador e a máquina encostarem e o bloqueio do jogador for falso 
                    if (picMaquina.Bounds.IntersectsWith(picJogador.Bounds) && !bloquearAtaque)
                    {
                        //Então a vida do jogador será reduzida
                        vidaJogador -= 10;
                    }

                    //O bloqueio da maquina é falso, pois está atacando
                    bloqueioMaquina = false;
                    break;

                //Se o ataque for bloqueio
                case "block":

                    //Então a imagem da maquina mudará
                    picMaquina.Image = Properties.Resources.enemy_block;

                    //O bloqueio da maquina é verdadeiro, pois está bloqueando
                    bloqueioMaquina = true;
                    break;
            }
        }              

        /// <summary>
        /// Evento que controla os ataques do jogador. Sempre que determinada
        /// tecla de ataque for pressionada, a imagem do personagem mudará e a
        /// maquina sofrerá danos, caso não esteja bloqueando. Também, o evento
        /// é responsável pelo movimento do jogador de um lado ao outro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teclaPraBaixo(object sender, KeyEventArgs e)
        {
            //Se a tecla K for pressionada
            if (e.KeyCode == Keys.K)
            {
                //O jogador se movimentará para a esquerda
                andarPraEsquerda = true;
            }

            //Se a tecla L for pressionada
            if (e.KeyCode == Keys.L)
            {
                //O jogador se movimentará para a direita
                andarPraDireita = true;
            }

            //Se a tecla pra baixo for pressionada
            if (e.KeyCode == Keys.Down)
            {
                //A imagem do personagem mudará para a imagem de bloqueio
                picJogador.Image = Properties.Resources.boxer_block;
                bloquearAtaque = true; //Altera para true o bloqueio do ataque
            }

            //Se a tecla pra esquerda for pressionada
            if (e.KeyCode == Keys.Left)
            {
                //A imagem do personagem mudará para a imagem de soco esquerda
                picJogador.Image = Properties.Resources.boxer_left_punch;

                //Ainda, se o ataque for enquanto o bloqueio da maquina for falso
                if (picMaquina.Bounds.IntersectsWith(picJogador.Bounds) && !bloqueioMaquina)
                {
                    //Então a vida da maquina será reduzida
                    vidaMaquina -= 5;
                }
            }

            //Se a tecla pra direita for pressionada
            if (e.KeyCode == Keys.Right)
            {
                //A imagem do personagem mudará para a imagem de soco direita
                picJogador.Image = Properties.Resources.boxer_right_punch;

                //Ainda, se o ataque for enquanto o bloqueio da maquina for falso
                if (picMaquina.Bounds.IntersectsWith(picJogador.Bounds) && !bloqueioMaquina)
                {
                    //Então a vida da maquina será reduzida e o jogador ganha 7 pontos
                    vidaMaquina -= 5;

                }
            }
        }

        /// <summary>
        /// Este evento será disparado toda vez que o evento teclaPraBaixo
        /// for finalizado, retornando a imagem do jogador, parando o movimento
        /// e retirando o movimento de bloqueio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teclaPraCima(object sender, KeyEventArgs e)
        {
            //Se parar de pressionar a tecla K
            if (e.KeyCode == Keys.K)
            {
                //Então o jogador para de andar
                andarPraEsquerda = false;
            }

            //Se parar de pressionar a tecla L
            if (e.KeyCode == Keys.L)
            {
                //Então o jogador para de andar
                andarPraDireita = false;
            }

            //Alteração da imagem para a imagem default
            picJogador.Image = Properties.Resources.boxer_stand;
            bloquearAtaque = false; //O bloqueio retorna a falso
        }

        /// <summary>
        /// Evento que controlará o movimento do jogador e o score ao vivo. Os
        /// booleanos permitem que o jogador se movimente ou fique parado,
        /// dependendo da condição.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eventoMovimentoJogador(object sender, EventArgs e)
        {
            //Se andarPra
            if (andarPraEsquerda)
            {
                //Então a distância entre o lado da esquerda da tela e o jogador será diminuida
                picJogador.Left -= velocidadeJogador;
            }

            if (andarPraDireita)
            {
                //Então a distância entre o lado da esquerda da tela e o jogador será acrescida
                picJogador.Left += velocidadeJogador;
            }
        }

        /// <summary>
        /// Método para reset do jogo, apresentando as opções de tentar
        /// novamente ou retornar para o menu principal.
        /// </summary>
        private void resetarJogo()
        {
            //Reinicia os três timers
            timerMaquina.Start();
            movimentoMaquina.Start();
            movimentoJogador.Start();
            timerCronometro.Start();

            contagemRegressiva = new TimeSpan(0, 0, 0, 10, 0);

            picJogador.Left = 355; //Reset da posição horizontal do jogador
            picJogador.Top = 335; //Reset da posição vertical do jogador
            picJogador.Image = Properties.Resources.boxer_stand; //Reset da imagem inicial do jogador

            picMaquina.Left = 385; //Reset da posição horizontal da maquina
            picMaquina.Top = 255; //Reset da posição vertical da maquina
            picMaquina.Image = Properties.Resources.enemy_stand; //Reset da imagem inicial da maquina

            vidaJogador = 100; //Reset da vida do jogador
            vidaMaquina = 100; //Reset da vida da maquina
        }

    }
}
