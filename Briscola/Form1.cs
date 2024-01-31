using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Briscola
{
    public partial class Form1 : Form
    {
        #region Members

        readonly bool testEnable = false; //show adversary's cards
        readonly string basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        List<String> pathCards;
        List<Card> cards;
        Deck deck;
        string briscolaSeed;
        int hand = 0;

        List<Card> opponentCards;
        List<Card> playerCards;
        Card briscolaCard;
        bool isPlayerWinner;

        Card opponentPlayedCard;
        PictureBox opponentNextHandBox;
        Label labelOpponent;

        List<Card> opponentCardsPlayedLastHand;
        

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();

            pathCards = new List<string>()
            {
                 Path.Combine(basePath, "Resources", "Bastoni", "asso.png"),
                 Path.Combine(basePath, "Resources", "Bastoni", "due.png"),
                 Path.Combine(basePath, "Resources", "Bastoni", "tre.png"),
                 Path.Combine(basePath, "Resources", "Bastoni", "quattro.png"),
                 Path.Combine(basePath, "Resources", "Bastoni", "cinque.png"),
                 Path.Combine(basePath, "Resources", "Bastoni", "sei.png"),
                 Path.Combine(basePath, "Resources", "Bastoni", "sette.png"),
                 Path.Combine(basePath, "Resources", "Bastoni", "donna.png"),
                 Path.Combine(basePath, "Resources", "Bastoni", "cavallo.png"),
                 Path.Combine(basePath, "Resources", "Bastoni", "re.png"),

                 Path.Combine(basePath, "Resources", "Denari", "asso.png"),
                 Path.Combine(basePath, "Resources", "Denari", "due.png"),
                 Path.Combine(basePath, "Resources", "Denari", "tre.png"),
                 Path.Combine(basePath, "Resources", "Denari", "quattro.png"),
                 Path.Combine(basePath, "Resources", "Denari", "cinque.png"),
                 Path.Combine(basePath, "Resources", "Denari", "sei.png"),
                 Path.Combine(basePath, "Resources", "Denari", "sette.png"),
                 Path.Combine(basePath, "Resources", "Denari", "donna.png"),
                 Path.Combine(basePath, "Resources", "Denari", "cavallo.png"),
                 Path.Combine(basePath, "Resources", "Denari", "re.png"),

                 Path.Combine(basePath, "Resources", "Spade", "asso.png"),
                 Path.Combine(basePath, "Resources", "Spade", "due.png"),
                 Path.Combine(basePath, "Resources", "Spade", "tre.png"),
                 Path.Combine(basePath, "Resources", "Spade", "quattro.png"),
                 Path.Combine(basePath, "Resources", "Spade", "cinque.png"),
                 Path.Combine(basePath, "Resources", "Spade", "sei.png"),
                 Path.Combine(basePath, "Resources", "Spade", "sette.png"),
                 Path.Combine(basePath, "Resources", "Spade", "donna.png"),
                 Path.Combine(basePath, "Resources", "Spade", "cavallo.png"),
                 Path.Combine(basePath, "Resources", "Spade", "re.png"),

                 Path.Combine(basePath, "Resources", "Coppe", "asso.png"),
                 Path.Combine(basePath, "Resources", "Coppe", "due.png"),
                 Path.Combine(basePath, "Resources", "Coppe", "tre.png"),
                 Path.Combine(basePath, "Resources", "Coppe", "quattro.png"),
                 Path.Combine(basePath, "Resources", "Coppe", "cinque.png"),
                 Path.Combine(basePath, "Resources", "Coppe", "sei.png"),
                 Path.Combine(basePath, "Resources", "Coppe", "sette.png"),
                 Path.Combine(basePath, "Resources", "Coppe", "donna.png"),
                 Path.Combine(basePath, "Resources", "Coppe", "cavallo.png"),
                 Path.Combine(basePath, "Resources", "Coppe", "re.png")     
            };

            cards = new List<Card>();
            opponentCards = new List<Card>();
            playerCards = new List<Card>();
            opponentCardsPlayedLastHand = new List<Card>();
        }

        #endregion

        public void EnablePictureBox(bool abilita)
        {
            pictureBoxIo1.Enabled = abilita;
            pictureBoxIo2.Enabled = abilita;
            pictureBoxIo3.Enabled = abilita;
        }

        public bool CheckHandWinningPlayer(Card vincente)
        {
            bool playerWinner = false;

            foreach (Card card in playerCards)
            {
                if (card == vincente)
                {
                    playerWinner = true;
                }
            }

            return playerWinner;
        }

        public Card DeterminePlayerCard(PictureBox box)
        {
            if (box == pictureBoxIo1)
            {
                return playerCards.ElementAt(0);
            }
            else if (box == pictureBoxIo2)
            {
                return playerCards.ElementAt(1);
            }
            else
            {
                return playerCards.ElementAt(2);
            }
        }

        public PictureBox DetermineOpponentCard(Card opponent)
        {
            PictureBox box = null;

            for (int i = 0; i < opponentCards.Count; i++)
            {
                if (opponent == opponentCards.ElementAt(i))
                {
                    if (i == 0)
                    {
                        box = pictureBoxAvversario1;
                    }
                    else if (i == 1)
                    {
                        box = pictureBoxAvversario2;
                    }
                    else
                    {
                        box = pictureBoxAvversario3;
                    }
                }
            }

            return box;
        }

        public Label DetermineOpponentLabel(Card opponent)
        {
            Label label = null;

            for (int i = 0; i < opponentCards.Count; i++)
            {
                if (opponent == opponentCards.ElementAt(i))
                {
                    if (i == 0)
                    {
                        label = labelRetro1;
                    }
                    else if (i == 1)
                    {
                        label = labelRetro2;
                    }
                    else
                    {
                        label = labelRetro3;
                    }
                }
            }

            return label;

        }

        public void PutPlayerCardInHand(PictureBox box, Card drawn)
        {
            if (box == pictureBoxIo1)
            {
                playerCards[0] = drawn;
            }
            else if (box == pictureBoxIo2)
            {
                playerCards[1] = drawn;
            }
            else
            {
                playerCards[2] = drawn;
            }

            box.ImageLocation = drawn.Path;
        }

        public void PutCardInOpponentHand(PictureBox box, Card drawn)
        {
            if (box == pictureBoxAvversario1)
            {
                opponentCards[0] = drawn;
                if(testEnable) 
                    label1.Text = drawn.Seed + " " + drawn.Number;
            }
            else if (box == pictureBoxAvversario2)
            {
                opponentCards[1] = drawn;
                if (testEnable)
                    label2.Text = drawn.Seed + " " + drawn.Number;
            }
            else
            {
                opponentCards[2] = drawn;
                if (testEnable)
                    label3.Text = drawn.Seed + " " + drawn.Number;
            }

            box.ImageLocation = drawn.Path;
        }

        public string CalculateMatchWinner()
        {
            int opponentPoints = Convert.ToInt32(labelPuntiAvversario.Text);
            int playerPoints = Convert.ToInt32(labelPunti.Text);

            if (opponentPoints > playerPoints)
            {
                return "YOU LOSE!";
            }
            else if(opponentPoints == playerPoints)
            {
                return "DRAW!";
            }
            else
            {
                return "YOU WIN!";
            }
        }

        public async Task<string> Wait()
        {
            // Add a using directive for System.Threading.
            await Task.Delay(1000);
            return "Finished";
        }

        public void AddPointsPlayer(bool isWinnerPlayer, Card player, Card opponent)
        {
            if (isWinnerPlayer)
            {
                // il vincitore della mano è il giocatore

                int sumPoints = player.Value + opponent.Value;

                labelPunti.Text = (Convert.ToInt32(labelPunti.Text) + sumPoints).ToString();
            }
            else
            {
                //il vincitore della mano è l'avversario

                int sumPoints = player.Value + opponent.Value;

                labelPuntiAvversario.Text = (Convert.ToInt32(labelPuntiAvversario.Text) + sumPoints).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < pathCards.Count; i++)
            {
                Card card = new Card(pathCards.ElementAt(i));
                cards.Add(card);
            }

            deck = new Deck(cards);

            deck = deck.ShuffleDeck(deck);

            playerCards = SetCardsToPlayers(new List<PictureBox>() { pictureBoxIo1, pictureBoxIo2, pictureBoxIo3 });
            opponentCards = SetCardsToPlayers(new List<PictureBox>() { pictureBoxAvversario1, pictureBoxAvversario2, pictureBoxAvversario3 }, true);

            briscolaCard = deck.GetCard(deck);
            briscolaSeed = briscolaCard.Seed;

            pictureBoxBriscola.Image = Image.FromFile(briscolaCard.Path);
            pictureBoxBriscola.Image.RotateFlip(RotateFlipType.Rotate90FlipX);

        }

        private async void pictureBoxIo2_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;

            if (hand == 0)
            {
                await FirstHand(box);
            }
            else if(hand == 16)
            {
                await PenultimateHand(box);
            }
            else if(hand >= 17)
            {
                await LastHand(box);
            }
            else
            {
                await StandardHand(box);
            }
        }

        private List<Card> SetCardsToPlayers(List<PictureBox> pictureBoxes, bool isOpponent = false)
        {
            List<Card> list_cards = new List<Card>();

            for (int i = 0; i < 3; i++)
            {
                Card card = deck.GetCard(deck);

                pictureBoxes[i].ImageLocation = card.Path;
                
                if (isOpponent && testEnable)
                {
                    //FOR TEST
                    if (i == 0) label1.Text = card.Seed + " " + card.Number;
                    else if(i==1) label2.Text = card.Seed + " " + card.Number;
                    else label3.Text = card.Seed + " " + card.Number;
                }

                list_cards.Add(card);
            }

            return list_cards;

        }

        private async Task FirstHand(PictureBox box)
        {
            box.Top = box.Location.Y - 50;

            EnablePictureBox(false);

            Card giocatore = DeterminePlayerCard(box);
            Card avv = Dealer.OpponentHandResponse(giocatore, opponentCards, briscolaSeed);

            labelOpponent = DetermineOpponentLabel(avv);
            labelOpponent.Visible = false;

            PictureBox boxAvv = DetermineOpponentCard(avv);
            boxAvv.Top = boxAvv.Location.Y + 50;

            Card vincente = Dealer.CalculateWinningCard(avv, giocatore, briscolaSeed);

            isPlayerWinner = CheckHandWinningPlayer(vincente);

            AddPointsPlayer(isPlayerWinner, giocatore, avv);

            _ = await Wait();

            box.Top = box.Location.Y + 50;
            boxAvv.Top = boxAvv.Location.Y - 50;

            labelOpponent.Visible = true;

            if (isPlayerWinner)
            {
                Card Io = deck.GetCard(deck);

                PutPlayerCardInHand(box, Io);

                Card avversario = deck.GetCard(deck);

                PutCardInOpponentHand(boxAvv, avversario);
            }
            else
            {
                Card avversario = deck.GetCard(deck);

                PutCardInOpponentHand(boxAvv, avversario);

                Card Io = deck.GetCard(deck);

                PutPlayerCardInHand(box, Io);

                opponentPlayedCard = Dealer.StartOpponentHand(opponentCards, briscolaSeed);

                labelOpponent = DetermineOpponentLabel(opponentPlayedCard);
                labelOpponent.Visible = false;

                opponentNextHandBox = DetermineOpponentCard(opponentPlayedCard);
                opponentNextHandBox.Top = opponentNextHandBox.Location.Y + 50;
            }

            EnablePictureBox(true);

            hand++;
        }

        private async Task PenultimateHand(PictureBox box)
        {
            //penultima mano dove alla fine si prende la briscola per terra
            if (!isPlayerWinner)
            {
                box.Top = box.Location.Y - 50;

                EnablePictureBox(false);

                Card giocatore = DeterminePlayerCard(box);

                Card vincente = Dealer.CalculateWinningCard(giocatore, opponentPlayedCard, briscolaSeed);

                isPlayerWinner = CheckHandWinningPlayer(vincente);

                AddPointsPlayer(isPlayerWinner, giocatore, opponentPlayedCard);

                _ = await Wait();

                box.Top = box.Location.Y + 50;
                opponentNextHandBox.Top = opponentNextHandBox.Location.Y - 50;

                labelOpponent.Visible = true;

                if (isPlayerWinner)
                {
                    Card Io = deck.GetCard(deck);

                    PutPlayerCardInHand(box, Io);

                    Card avversario = briscolaCard;

                    PutCardInOpponentHand(opponentNextHandBox, avversario);

                    pictureBoxBriscola.Visible = false;
                }
                else
                {
                    Card avversario = deck.GetCard(deck);

                    PutCardInOpponentHand(opponentNextHandBox, avversario);

                    Card Io = briscolaCard;

                    PutPlayerCardInHand(box, Io);

                    pictureBoxBriscola.Visible = false;

                    opponentPlayedCard = Dealer.StartOpponentHand(opponentCards, briscolaSeed);

                    labelOpponent = DetermineOpponentLabel(opponentPlayedCard);
                    labelOpponent.Visible = false;

                    opponentNextHandBox = DetermineOpponentCard(opponentPlayedCard);
                    opponentNextHandBox.Top = opponentNextHandBox.Location.Y + 50;
                }

                EnablePictureBox(true);

                pictureBoxMazzo.Visible = false;

                hand++;
            }
            else
            {
                box.Top = box.Location.Y - 50;

                EnablePictureBox(false);

                Card giocatore = DeterminePlayerCard(box);
                Card avv = Dealer.OpponentHandResponse(giocatore, opponentCards, briscolaSeed);

                labelOpponent = DetermineOpponentLabel(avv);
                labelOpponent.Visible = false;

                PictureBox boxAvv = DetermineOpponentCard(avv);
                boxAvv.Top = boxAvv.Location.Y + 50;

                Card vincente = Dealer.CalculateWinningCard(avv, giocatore, briscolaSeed);

                isPlayerWinner = CheckHandWinningPlayer(vincente);

                AddPointsPlayer(isPlayerWinner, giocatore, avv);

                _ = await Wait();

                box.Top = box.Location.Y + 50;
                boxAvv.Top = boxAvv.Location.Y - 50;

                labelOpponent.Visible = true;

                if (isPlayerWinner)
                {
                    Card Io = deck.GetCard(deck);

                    PutPlayerCardInHand(box, Io);

                    Card avversario = briscolaCard;

                    pictureBoxBriscola.Visible = false;

                    PutCardInOpponentHand(boxAvv, avversario);
                }
                else
                {
                    Card avversario = deck.GetCard(deck);

                    PutCardInOpponentHand(boxAvv, avversario);

                    Card Io = briscolaCard;

                    PutPlayerCardInHand(box, Io);

                    pictureBoxBriscola.Visible = false;

                    opponentPlayedCard = Dealer.StartOpponentHand(opponentCards, briscolaSeed);

                    labelOpponent = DetermineOpponentLabel(opponentPlayedCard);
                    labelOpponent.Visible = false;

                    opponentNextHandBox = DetermineOpponentCard(opponentPlayedCard);
                    opponentNextHandBox.Top = opponentNextHandBox.Location.Y + 50;
                }

                EnablePictureBox(true);

                pictureBoxMazzo.Visible = false;

                hand++;
            }
        }

        private async Task LastHand(PictureBox box)
        {
            //ultima mano non ci sono più carte da pescare
            if (!isPlayerWinner)
            {
                box.Top = box.Location.Y - 50;

                EnablePictureBox(false);

                Card giocatore = DeterminePlayerCard(box);

                Card vincente = Dealer.CalculateWinningCard(giocatore, opponentPlayedCard, briscolaSeed);

                opponentCardsPlayedLastHand.Add(opponentPlayedCard);

                isPlayerWinner = CheckHandWinningPlayer(vincente);

                AddPointsPlayer(isPlayerWinner, giocatore, opponentPlayedCard);

                _ = await Wait();

                box.Top = box.Location.Y + 50;
                opponentNextHandBox.Top = opponentNextHandBox.Location.Y - 50;
                box.Visible = false;
                opponentNextHandBox.Visible = false;

                labelOpponent.Visible = false;

                if (isPlayerWinner)
                {
                    if (hand == 19)
                    {
                        MessageBox.Show(CalculateMatchWinner());
                    }
                }
                else
                {
                    if (hand == 19)
                    {
                        MessageBox.Show(CalculateMatchWinner());
                    }
                    else
                    {
                        opponentPlayedCard = Dealer.StartOpponentHand(opponentCards, opponentCardsPlayedLastHand, briscolaSeed, hand);

                        labelOpponent = DetermineOpponentLabel(opponentPlayedCard);
                        labelOpponent.Visible = false;

                        opponentNextHandBox = DetermineOpponentCard(opponentPlayedCard);
                        opponentNextHandBox.Top = opponentNextHandBox.Location.Y + 50;
                    }
                }

                EnablePictureBox(true);

                hand++;
            }
            else
            {
                box.Top = box.Location.Y - 50;

                EnablePictureBox(false);

                Card giocatore = DeterminePlayerCard(box);

                Card avv = Dealer.OpponentHandResponse(giocatore, playerCards, opponentCards, opponentCardsPlayedLastHand, briscolaSeed, hand);

                opponentCardsPlayedLastHand.Add(avv);

                labelOpponent = DetermineOpponentLabel(avv);
                labelOpponent.Visible = false;

                PictureBox boxAvv = DetermineOpponentCard(avv);
                boxAvv.Top = boxAvv.Location.Y + 50;

                Card vincente = Dealer.CalculateWinningCard(avv, giocatore, briscolaSeed);

                isPlayerWinner = CheckHandWinningPlayer(vincente);

                AddPointsPlayer(isPlayerWinner, giocatore, avv);

                _ = await Wait();

                box.Top = box.Location.Y + 50;
                boxAvv.Top = boxAvv.Location.Y - 50;
                box.Visible = false;
                boxAvv.Visible = false;

                labelOpponent.Visible = false;

                if (isPlayerWinner)
                {
                    if (hand == 19)
                    {
                        MessageBox.Show(CalculateMatchWinner());
                    }
                }
                else
                {
                    if (hand == 19)
                    {
                        MessageBox.Show(CalculateMatchWinner());
                    }
                    else
                    {
                        opponentPlayedCard = Dealer.StartOpponentHand(opponentCards, opponentCardsPlayedLastHand, briscolaSeed, hand);

                        labelOpponent = DetermineOpponentLabel(opponentPlayedCard);
                        labelOpponent.Visible = false;

                        opponentNextHandBox = DetermineOpponentCard(opponentPlayedCard);
                        opponentNextHandBox.Top = boxAvv.Location.Y + 50;
                    }
                }

                EnablePictureBox(true);

                hand++;
            }
        }

        private async Task StandardHand(PictureBox box)
        {
            if (!isPlayerWinner)
            {
                box.Top = box.Location.Y - 50;

                EnablePictureBox(false);

                Card giocatore = DeterminePlayerCard(box);

                Card vincente = Dealer.CalculateWinningCard(giocatore, opponentPlayedCard, briscolaSeed);

                isPlayerWinner = CheckHandWinningPlayer(vincente);

                AddPointsPlayer(isPlayerWinner, giocatore, opponentPlayedCard);

                _ = await Wait();

                box.Top = box.Location.Y + 50;
                opponentNextHandBox.Top = opponentNextHandBox.Location.Y - 50;

                labelOpponent.Visible = true;

                if (isPlayerWinner)
                {
                    Card Io = deck.GetCard(deck);

                    PutPlayerCardInHand(box, Io);

                    Card avversario = deck.GetCard(deck);

                    PutCardInOpponentHand(opponentNextHandBox, avversario);
                }
                else
                {
                    Card avversario = deck.GetCard(deck);

                    PutCardInOpponentHand(opponentNextHandBox, avversario);

                    Card Io = deck.GetCard(deck);

                    PutPlayerCardInHand(box, Io);

                    opponentPlayedCard = Dealer.StartOpponentHand(opponentCards, briscolaSeed);

                    labelOpponent = DetermineOpponentLabel(opponentPlayedCard);
                    labelOpponent.Visible = false;

                    opponentNextHandBox = DetermineOpponentCard(opponentPlayedCard);
                    opponentNextHandBox.Top = opponentNextHandBox.Location.Y + 50;
                }

                EnablePictureBox(true);

                hand++;
            }
            else
            {
                box.Top = box.Location.Y - 50;

                EnablePictureBox(false);

                Card giocatore = DeterminePlayerCard(box);
                Card avv = Dealer.OpponentHandResponse(giocatore, opponentCards, briscolaSeed);

                labelOpponent = DetermineOpponentLabel(avv);
                labelOpponent.Visible = false;

                PictureBox boxAvv = DetermineOpponentCard(avv);
                boxAvv.Top = boxAvv.Location.Y + 50;

                Card vincente = Dealer.CalculateWinningCard(avv, giocatore, briscolaSeed);

                isPlayerWinner = CheckHandWinningPlayer(vincente);

                AddPointsPlayer(isPlayerWinner, giocatore, avv);

                _ = await Wait();

                box.Top = box.Location.Y + 50;
                boxAvv.Top = boxAvv.Location.Y - 50;

                labelOpponent.Visible = true;

                if (isPlayerWinner)
                {
                    Card Io = deck.GetCard(deck);

                    PutPlayerCardInHand(box, Io);

                    Card avversario = deck.GetCard(deck);

                    PutCardInOpponentHand(boxAvv, avversario);
                }
                else
                {
                    Card avversario = deck.GetCard(deck);

                    PutCardInOpponentHand(boxAvv, avversario);

                    Card Io = deck.GetCard(deck);

                    PutPlayerCardInHand(box, Io);

                    opponentPlayedCard = Dealer.StartOpponentHand(opponentCards, briscolaSeed);

                    labelOpponent = DetermineOpponentLabel(opponentPlayedCard);
                    labelOpponent.Visible = false;

                    opponentNextHandBox = DetermineOpponentCard(opponentPlayedCard);
                    opponentNextHandBox.Top = opponentNextHandBox.Location.Y + 50;
                }

                EnablePictureBox(true);

                hand++;
            }
        }
    }
}
