using System;
using System.Collections.Generic;

namespace Briscola
{
    public static class Dealer
    {
        public static Card OpponentHandResponse(Card player, List<Card> opponent, string briscola)
        {
            bool isPlayerBriscola = (player.Seed == briscola);

            if (isPlayerBriscola)
            {
                if (player.Number == 1)
                {
                    return CheckLowerCard(opponent, briscola);
                }
                else if (player.Number == 3)
                {
                    Card asso = CheckAceOfBriscola(opponent, briscola);
                    return asso ?? CheckLowerCard(opponent, briscola);
                }
                else if (player.Number == 8 || player.Number == 9)
                {
                    Card lowCard = CheckLowerCard(opponent, briscola);
                    return (lowCard.Value >= 10) ? CheckLowerBriscola(opponent, briscola) ?? lowCard : lowCard;
                }
                else
                {
                    return CheckLowerCard(opponent, briscola);
                }
            }
            else
            {
                if (player.Value == 11)
                {
                    return CheckLowerBriscola(opponent, briscola) ?? CheckThreeOfBriscola(opponent, briscola) ?? CheckAceOfBriscola(opponent, briscola) ?? CheckLowerCard(opponent, briscola);
                }
                else if (player.Value == 10)
                {
                    return CheckAcePossession(opponent, player) ?? CheckLowerBriscola(opponent, briscola) ?? CheckAceOfBriscola(opponent, briscola) ?? CheckThreeOfBriscola(opponent, briscola) ?? CheckLowerCard(opponent, briscola);
                }
                else if (player.Value == 4)
                {
                    return CheckCaricoPossession(opponent, player) ?? CheckLowerCard(opponent, briscola);
                }
                else if (player.Value == 0)
                {
                    return CheckCaricoPossession(opponent, player) ?? CheckPointPossession(opponent, player) ?? CheckLowerCard(opponent, briscola);
                }
                else
                {
                    return CheckCaricoPossession(opponent, player) ?? CheckPointPossession(opponent, player) ?? CheckLowerCard(opponent, briscola);
                }
            }
        }

        public static Card OpponentHandResponse(Card player, List<Card> playedCards, List<Card> opponent, List<Card> previousHandCards, string briscola, int hand)
        {
            List<Card> opponentCopy = new List<Card>(opponent);

            if (hand == 17 || (hand >= 18 && hand <= 19))
            {
                foreach (Card cartaPrec in previousHandCards)
                {
                    opponentCopy.Remove(cartaPrec);
                }

                // verifico se possiedo il tre di briscola
                Card threeCard = CheckThreeOfBriscola(opponentCopy, briscola);

                if (threeCard != null)
                {
                    Card playerAce = CheckAceOfBriscola(playedCards, briscola);

                    if (playerAce == null)
                    {
                        return OpponentHandResponse(player, opponentCopy, briscola);
                    }
                    else
                    {
                        if (player.Value == 0 || player.Value < 10)
                        {
                            Card cardResponse = OpponentHandResponse(player, opponentCopy, briscola);
                            Card winningCard = CalculateWinningCard(cardResponse, player, briscola);

                            if (winningCard == cardResponse)
                            {
                                if (cardResponse.Value == 11)
                                {
                                    return cardResponse;
                                }
                                else
                                {
                                    return threeCard;
                                }
                            }
                            else
                            {
                                if (cardResponse.Value >= 10)
                                {
                                    return threeCard;
                                }
                                else
                                {
                                    return cardResponse;
                                }
                            }
                        }
                        else
                        {
                            if (player.Seed != briscola)
                            {
                                Card caricoAce = CheckAcePossession(opponentCopy, player);

                                if (caricoAce != null)
                                {
                                    return caricoAce;
                                }
                                else
                                {
                                    return threeCard;
                                }
                            }
                            else
                            {
                                return OpponentHandResponse(player, opponentCopy, briscola);
                            }
                        }
                    }
                }
                else
                {
                    return OpponentHandResponse(player, opponentCopy, briscola);
                }
            }
            else
            {
                return OpponentHandResponse(player, opponent, briscola);
            }
        }

        [Obsolete]
        public static Card OpponentHandResponse_Old(Card player, List<Card> opponent, string briscola)
        {
            bool isPlayerBriscola = (player.Seed == briscola);

            // se il giocatore gioca una briscola
            if (isPlayerBriscola)
            {
                // se il giocatore butta l'asso di briscola
                if (player.Number == 1)
                {
                    Card lowerCard = CheckLowerCard(opponent, briscola);

                    return lowerCard;
                }
                // se il giocatore butta il 3 di briscola
                else if (player.Number == 3)
                {
                    Card ace = CheckAceOfBriscola(opponent, briscola);

                    // se l'avversario ha l'asso di briscola butta l'asso
                    if (ace != null)
                    {
                        return ace;
                    }
                    // altrimenti l'avversario butta la carta più bassa
                    else
                    {
                        Card lowerCard = CheckLowerCard(opponent, briscola);

                        return lowerCard;
                    }
                }
                // se il giocatore butta la donna di briscola
                else if(player.Number==8)
                {
                    Card lowerCard = CheckLowerCard(opponent, briscola);

                    // se la carta più bassa trovata è un carico
                    if (lowerCard.Value >= 10)
                    {
                        // cerco la briscola più bassa
                        Card lowerBriscola = CheckLowerBriscola(opponent, briscola);

                        // se non la trovo vuol dire che non ho briscole oppure ho l'asso o il 3 di briscola
                        if (lowerBriscola == null)
                        {
                            // lancio il carico
                            return lowerCard;
                        }
                        else
                        {
                            // lancio la briscola più bassa
                            return lowerBriscola;
                        }
                    }
                    // se la carta più bassa è un re
                    else if (lowerCard.Value == 4)
                    { 
                        // verifico se ho il re di briscola
                        Card king = CheckKingOfBriscola(opponent, briscola);

                        // se non lo trovo
                        if (king == null)
                        {
                            // verifico se ho il cavallo di briscola
                            Card knight = CheckKnightOfBriscola(opponent, briscola);

                            // se non lo trovo lancio il re 
                            if (knight == null)
                            {
                                return lowerCard;
                            }
                            else
                            {
                                // altrimenti gioco il cavallo di briscola
                                return knight;
                            }
                        }
                        else
                        {
                            // altrimenti gioco il re di briscola
                            return king;
                        }
                    }
                    else
                    {
                        // se la carta più bassa è un cavallo o meno gioco quella
                        return lowerCard;
                    }
                }
                    // se il giocatore butta il cavallo di briscola
                else if (player.Number == 9) // da programmare prima di cercare il re di brsicola e se ho più di una briscola
                {
                    Card lowerCard = CheckLowerCard(opponent, briscola);

                    // se la carta più bassa è un carico
                    if (lowerCard.Value >= 10)
                    {
                        // cerco la briscola più bassa
                        Card lowerBriscola = CheckLowerBriscola(opponent, briscola);

                        // se non la trovo vuol dire che non ho briscole oppure ho l'asso o il 3 di briscola
                        if (lowerBriscola == null)
                        {
                            // lancio il carico
                            return lowerCard;
                        }
                        else
                        {
                            // lancio la briscola più bassa
                            return lowerBriscola;
                        }
                    }
                     // se la carta più bassa è un re
                    else if (lowerCard.Value == 4)
                    {
                        // verifico se ho il re di briscola
                        Card king = CheckKingOfBriscola(opponent, briscola);

                        // se non trovo il re restituisco il re 
                        if (king == null)
                        {
                            return lowerCard;
                        }
                        else
                        {
                            // altrimenti gioco il re di briscola
                            return king;
                        }
                    }
                    else
                    {
                        // se la carta più bassa è un cavallo o meno gioco quella
                        return lowerCard;
                    }
                }
                    // se butta un'altra qualsiasi briscola
                else
                {
                    Card lowerCard = CheckLowerCard(opponent, briscola);

                    // se la carta più bassa è un carico
                    if (lowerCard.Value >= 10)
                    {
                        // cerco la briscola più bassa
                        Card lowerBriscola = CheckLowerBriscola(opponent, briscola);

                        // se non la trovo vuol dire che non ho briscole oppure ho l'asso o il 3 di briscola
                        if (lowerBriscola == null)
                        {
                            // lancio il carico
                            return lowerCard;
                        }
                        else
                        {
                            // lancio la briscola più bassa
                            return lowerBriscola;
                        }
                    }
                    else
                    {
                        // se la carta più bassa non è un carico gioco quella
                        return lowerCard;
                    }
                }
            }
                // se il giocatore non gioca la briscola
            else
            {
                // se il giocatore lancia un asso
                if (player.Value == 11)
                {
                    // verifico se ho una briscola che non sia un carico
                    Card opponentBriscola = CheckLowerBriscola(opponent, briscola);

                    // se non la trovo
                    if (opponentBriscola == null)
                    {
                        // verifico se possiedo il tre di briscola
                        Card threeCard = CheckThreeOfBriscola(opponent, briscola);

                        // se non la possiedo
                        if (threeCard == null)
                        {
                            // verifico se possiedo l'asso di briscola
                            Card ace = CheckAceOfBriscola(opponent, briscola);

                            // se non la possiedo
                            if (ace == null)
                            {
                                // lancio la carta più basso che possiedo
                                Card lowerCard = CheckLowerCard(opponent, briscola);

                                return lowerCard;
                            }
                            else
                            {
                                // se ho l'asso di briscola lo lancio
                                return ace;
                            }
                        }
                        else
                        {
                            // se ho il tre di briscola lo lancio
                            return threeCard;
                        }
                    }
                    else
                    {
                        // se ho una briscola bassa la lancio
                        return opponentBriscola;
                    }
                }
                    // se il giocatore lancia un tre
                else if (player.Value == 10)
                {
                    // verico se possiedo l'asso dello stesso seme
                    Card ace=CheckAcePossession(opponent, player);

                    // se non ce l'ho
                    if (ace == null)
                    {
                        // verifico se possiedo una briscola bassa
                        Card lowerBriscola = CheckLowerBriscola(opponent, briscola);

                        // se non possiedo una briscola bassa
                        if (lowerBriscola == null)
                        {
                            // verifico se possiedo 'asso di briscola
                            Card aceBriscola = CheckAceOfBriscola(opponent, briscola);

                            // se non lo possiedo
                            if (aceBriscola == null)
                            {
                                // verifico se possiedo il tre di briscola
                                Card threeCard=CheckThreeOfBriscola(opponent, briscola);

                                // se non lo possiedo
                                if (threeCard == null)
                                {
                                    // lancio la carta più bassa che possiedo
                                    Card lowerCard = CheckLowerCard(opponent, briscola);

                                    return lowerCard;
                                }
                                else
                                {
                                    // se possiedo il tre di briscola lo lancio
                                    return threeCard;
                                }
                            }
                            else
                            {
                                // se possiedo l'asso di briscola lo lancio
                                return aceBriscola;
                            }
                        }
                        else
                        {
                            // se possiedo una briscola bassa la lancio
                            return lowerBriscola;
                        }
                    }
                    else
                    {
                        // se ho l'asso dello stesso seme lo lancio
                        return ace;
                    }
                }
                    // se il giocatore lancia un re
                else if (player.Value == 4)
                {
                    //verifico se possiedo il carico dello stesso seme
                    Card carico = CheckCaricoPossession(opponent, player);

                    // se non lo possiedo
                    if (carico == null)
                    {
                        // prelevo la carta più bassa non di briscola
                        Card lowerCard = CheckLowerCard(opponent, briscola);

                        // se la carta è un liscio lo lancio
                        if (lowerCard.Value == 0)
                        {
                            return lowerCard;
                        }
                            // se la carta più bassa è un re
                        else if (lowerCard.Value == 4)
                        {
                            //verifico se ho una briscola bassa
                            Card lowerBriscola = CheckLowerBriscola(opponent, briscola);

                            // se possiedo una briscola bassa
                            if (lowerBriscola != null)
                            {
                                // verifico che la briscola sia un liscio
                                if (lowerBriscola.Value == 0)
                                {
                                    // se è un liscio la lancio
                                    return lowerBriscola;
                                }
                                    // se la briscola non è un liscio
                                else
                                {
                                    // lancio il re ovvero la carta più bassa
                                    return lowerCard;
                                }
                            }
                                // se non possiedo una briscola bassa
                            else
                            {
                                // gioco la carta più bassa
                                return lowerCard;
                            }
                        }
                            // se la carta più bassa è un carico
                        else if (lowerCard.Value >= 10) 
                        {
                            //verifico se possiedo una briscola bassa
                            Card lowerBriscola = CheckLowerBriscola(opponent, briscola);

                            // se possiedo una briscola bassa la gioco
                            if (lowerBriscola != null)
                            {
                                return lowerBriscola;
                            }
                                // se non ho una briscola bassa
                            else
                            {
                                //gioco la carta bassa
                                return lowerCard;
                            }

                        }
                            // se la carta più bassa non è un carico un liscio o un re
                        else
                        {
                            // ritorno la carta più bassa
                            return lowerCard;
                        }
                    }
                    else
                    {
                        // se ho il carico dello stesso seme lo lancio
                        return carico;
                    }
                }
                    // se il giocatore gioco un liscio
                else if (player.Value == 0)
                {
                    //verifico se possiedo il carico dello stesso seme
                    Card carico = CheckCaricoPossession(opponent, player);

                    // se non possiedo un carico dello stesso seme
                    if (carico == null)
                    {
                        // verifico se ho dei punti per prendere
                        Card points = CheckPointPossession(opponent, player);

                        // se non posseggo dei punti dello stesso seme per prendere
                        if (points == null)
                        {
                            // verifico quale sia la mia carta più bassa
                            Card lowerCard = CheckLowerCard(opponent, briscola);

                            // se la mia carta più bassa è un liscio lo lancio
                            if (lowerCard.Value == 0)
                            {
                                return lowerCard;
                            }
                                // se la carta più bassa è un carico
                            else if (lowerCard.Value >= 10)
                            {
                                //verifico se possiedo una briscola bassa
                                Card lowerBriscola = CheckLowerBriscola(opponent, briscola);
                                
                                //se non possiedo una briscola bassa
                                if (lowerBriscola == null)
                                {
                                    //lancio la carta più bassa
                                    return lowerCard;
                                }
                                    // se possiedo una briscola bassa la lancio
                                else
                                {
                                    return lowerBriscola;
                                }
                            }
                                // se la carta più bassa non è un carico 
                            else
                            {
                                // lancio la carta più bassa
                                return lowerCard;
                            }
                        }
                            // se ho dei punti per prendere lo lancio
                        else
                        {
                            return points;
                        }
                    }
                    else
                    {
                        // se possiedo il carico dello stesso seme lo gioco
                        return carico;
                    }
                }
                    // se il giocatore gioca una donna o un cavallo
                else
                {
                    //verifico se possiedo un carico dello stesso seme
                    Card carico = CheckCaricoPossession(opponent, player);

                    // se possiedo un carico lo lancio
                    if (carico != null)
                    {
                        return carico;
                    }
                        // se non possiedo un carico dello stesso seme
                    else
                    {
                        // verifico se ho dei punti da prendere
                        Card points = CheckPointPossession(opponent, player);

                        // se ho dei punti per prendere lancio la carta
                        if (points != null)
                        {
                            return points;
                        }
                            // se non ho punti per prendere
                        else
                        {
                            // verifico la mia carta più bassa
                            Card lowerCard = CheckLowerCard(opponent, briscola);

                            // se la mia carta più bassa è un liscio lo lancio
                            if (lowerCard.Value == 0)
                            {
                                return lowerCard;
                            }
                            // se la carta più bassa è un carico
                            else if (lowerCard.Value >= 10)
                            {
                                //verifico se possiedo una briscola bassa
                                Card lowerBriscola = CheckLowerBriscola(opponent, briscola);

                                // se possiedo una briscola bassa la lancio
                                if (lowerBriscola != null)
                                {
                                    return lowerBriscola;
                                }
                                // se non possiedo una briscola bassa ritorno la carta più bassa
                                else
                                {
                                    return lowerCard;
                                }
                            }
                            // se la carta bassa non è un carico o un liscio
                            else
                            {
                                return lowerCard;
                            }
                        }
                    }
                }
            }
        }

        [Obsolete]
        public static Card OpponentHandResponse_Old(Card player,List<Card> playerCards, List<Card> opponent, List<Card> previousHandCards, string briscola, int hand)
        {
            List<Card> opponentCopy = new List<Card>();
            opponentCopy.AddRange(opponent);

            if (hand == 17)
            {
                // verifico se l'avversario possiede il tre di briscola
                Card three = CheckThreeOfBriscola(opponent, briscola);

                // se possiedo il tre di briscola
                if (three != null)
                {
                    // verifico se il giocatore possiede l'asso di briscola
                    Card playerAce = CheckAceOfBriscola(playerCards, briscola);

                    // se il giocatore non possiede l'asso
                    if (playerAce == null)
                    {
                        // rispondo alla mano con il solito algoritmo
                        return OpponentHandResponse(player, opponent, briscola);
                    }
                    // se invece il giocatore possiede l'asso di briscola
                    else
                    {
                        // verifico il valore della carta tirata dal giocatore per determinare se tirare subito il tre di briscola
                        if (player.Value == 0 || player.Value < 10)
                        {
                            // controllo quale carta tirerei col il solito algoritmo e se ne sarei il vincitore
                            Card responseCard = OpponentHandResponse(player, opponent, briscola);

                            Card winningCard = CalculateWinningCard(responseCard, player, briscola);

                            // se fossi il vincitore tiro il tre di briscola
                            if (winningCard == responseCard)
                            {
                                // se vincerei la mano tirando un asso allora lo tiro
                                if (responseCard.Value == 11)
                                {
                                    return responseCard;
                                }
                                else
                                {
                                    // altrimenti tiro il tre di briscola
                                    return three;
                                }
                            }
                                // se non sarei il vincitore della mano
                            else
                            {
                                // se la carte che lancerei è un carico
                                if (responseCard.Value >= 10)
                                {
                                    // tiro il tre di briscola
                                    return three;
                                }
                                else
                                {
                                    // altrimenti gioco la carte usando il solito algoritmo
                                    return responseCard;
                                }
                            }
                        }
                            // se il giocatore butta un carico
                        else
                        {
                            // se il carico lanciato dal giocatore non è di briscola
                            if (player.Seed != briscola)
                            {
                                //verifico il possesso dell'asso dello stesso seme se la carta giocata è un tre
                                Card aceCarico = CheckAcePossession(opponent, player);

                                // se l'avversario possiede l'asso dello stesso seme
                                if (aceCarico != null)
                                {
                                    // lancio il carico
                                    return aceCarico;
                                }
                                else
                                {
                                    // se non possiedo l'asso dello stesso seme lancio il tre di briscola
                                    return three;
                                }
                            }
                            else
                            {
                                // se il giocatore lancia un carico di briscola uso lo stesso algoritmo per rispondere
                                return OpponentHandResponse(player, opponent, briscola);
                            }
                        }
                    }
                }
                    // se non possiedo il tre di briscola
                else
                {
                    // uso il solito algoritmo per rispondere alla mano
                    return OpponentHandResponse(player, opponent, briscola);
                }
            }
            else if (hand == 18 || hand == 19)
            {
                foreach (Card previousCard in previousHandCards)
                {
                    opponentCopy.Remove(previousCard);
                }

                // verifico se possiedo il tre di briscola
                Card three = CheckThreeOfBriscola(opponentCopy, briscola);

                // se possiedo il tre di briscola
                if (three != null)
                {
                    // verifico se il giocatore possiede l'asso di briscola
                    Card playerAce = CheckAceOfBriscola(playerCards, briscola);

                    // se il giocatore non possiede l'asso
                    if (playerAce == null)
                    {
                        // rispondo alla mano con il solito algoritmo
                        return OpponentHandResponse(player, opponentCopy, briscola);
                    }
                        // se il giocatore possiede l'asso di briscola
                    else
                    {
                        // verifico il valore della carta tirata dal giocatore per determinare se tirare subito il tre di briscola
                        if (player.Value == 0 || player.Value < 10)
                        {
                            // controllo quale carta tirerei col il solito algoritmo e se ne sarei il vincitore
                            Card responseCard = OpponentHandResponse(player, opponentCopy, briscola);

                            Card winningCard = CalculateWinningCard(responseCard, player, briscola);

                            // se fossi il vincitore tiro il tre di briscola
                            if (winningCard == responseCard)
                            {
                                // se vincerei la mano tirando un asso allora lo tiro
                                if (responseCard.Value == 11)
                                {
                                    return responseCard;
                                }
                                else
                                {
                                    // altrimenti tiro il tre di briscola
                                    return three;
                                }
                            }
                                // se non sarei il vincitore della mano lancio il tre di briscola
                            else 
                            {
                                return three;
                            }
                        }
                        // se il giocatore butta un carico
                        else
                        {
                            // se il carico lanciato dal giocatore non è di briscola
                            if (player.Seed != briscola)
                            {
                                //verifico il possesso dell'asso dello stesso seme se la carta giocata è un tre
                                Card aceCarico = CheckAcePossession(opponentCopy, player);

                                // se l'avversario possiede l'asso dello stesso seme
                                if (aceCarico != null)
                                {
                                    // lancio il carico
                                    return aceCarico;
                                }
                                else
                                {
                                    // se non possiedo l'asso dello stesso seme lancio il tre di briscola
                                    return three;
                                }
                            }
                            else
                            {
                                // se il giocatore lancia un carico di briscola uso lo stesso algoritmo per rispondere
                                return OpponentHandResponse(player, opponentCopy, briscola);
                            }
                        }
                    }
                }
                    // se non possiedo il tre di briscola
                else
                {
                    // uso il solito algoritmo per rispondere alla mano
                    return OpponentHandResponse(player, opponentCopy, briscola);
                }
            } 
                // se la mano non è tra la 17 alla 19
            else
            {
                return OpponentHandResponse(player, opponent, briscola);
            }
        }

        public static Card CheckPointPossession(List<Card> opponentCards, Card player)
        {
            Card points = null;

            foreach (Card card in opponentCards)
            {
                if (card.Seed == player.Seed)
                {
                    if (card.Value ==4)
                    {
                        points = card;
                    }
                    else if (card.Value == 3)
                    {
                        points = card;
                    }
                    else if (card.Value == 2)
                    {
                        points = card;
                    }
                }
            }

            return points;
        }

        public static Card CheckAcePossession(List<Card> opponentCards, Card player)
        {
            Card ace = null;

            foreach (Card carta in opponentCards)
            {
                // se la carta è dello stesso seme
                if (carta.Seed == player.Seed)
                {
                    //verifico se la carta sia l'asso
                    if (carta.Value == 11)
                    {
                        // lancio l'asso
                        ace = carta;
                    }
                }
            }

            return ace;
        }

        public static Card CheckCaricoPossession(List<Card> opponentCards, Card player)
        {
            Card carico = null;

            foreach (Card card in opponentCards)
            {
                // se la carta è dello stesso seme
                if (card.Seed == player.Seed)
                {
                    //verifico che la carta sia un carico
                    if (card.Value >= 10)
                    {
                        //se la carta è un carico lo lancio
                        carico = card;
                    }
                }
            }

            return carico;
        }

        public static Card CheckKingOfBriscola(List<Card> opponentCards, string briscola)
        {
            Card king = null;

            foreach (Card card in opponentCards)
            {
                if (card.Seed == briscola)
                {
                    if (card.Value == 4)
                    {
                        king = card;
                    }
                }
            }

            return king;
        }

        public static Card CheckKnightOfBriscola(List<Card> opponentCards, string briscola)
        {
            Card knight = null;

            foreach (Card card in opponentCards)
            {
                if (card.Seed == briscola)
                {
                    if (card.Value == 3)
                    {
                        knight = card;
                    }
                }
            }

            return knight;
        }

        public static Card CheckLowerBriscola(List<Card> opponentCards, string briscola)
        {
            Card lowerBriscola = null;

            foreach (Card card in opponentCards)
            {
                // se la carta è una briscola
                if (card.Seed == briscola)
                {
                    //verifico se è la prima briscola trovata
                    if (lowerBriscola == null)
                    {
                        // se la briscola non è un carico
                        if (card.Value < 10)
                        {
                            // metto la briscola nella briscola più bassa trovata
                            lowerBriscola = card;
                        }
                    }
                        // se ho già trovato un'altra briscola
                    else
                    {
                        // controllo che la carta abbia un valore più basso della briscolaBassa corrente
                        if (card.Value < lowerBriscola.Value)
                        {
                            // e la sostituisco
                            lowerBriscola = card;
                        }
                    }
                }
            }

            return lowerBriscola;
        }

        public static Card CheckLowerCard(List<Card> opponentCards, string briscola)
        {
            Card lowerCard = null;

            foreach (Card card in opponentCards)
            {
                // se la carta corrente non è una briscola
                if (card.Seed != briscola)
                {
                    // se è la prima carta che immetto nella bassa
                    if (lowerCard == null)
                    {
                        //metto la carta corrente nella bassa
                        lowerCard = card;
                    }
                        // se c'è già una carta bassa
                    else
                    {
                        // se la bassa ha un valore e la carta corrente è un liscio cambio la carta bassa
                        if (card.Value == 0 && lowerCard.Value > 0)
                        {
                            lowerCard = card;
                        }
                        // se la bassa è un asso metto come temporanea la carta corrente                           
                        else if (card.Value < 11 && lowerCard.Value == 11)
                        {
                            lowerCard = card;
                        }
                            // se la bassa è un 3 e la carta è più bassa la metto come nuova bassa
                        else if (card.Value < 10 && lowerCard.Value == 10)
                        {
                            lowerCard = card;
                        }
                            // se la bassa è un re e la carta è un cavallo metto la carta come nuova bassa
                        else if (card.Value < 4 && lowerCard.Value == 4)
                        {
                            lowerCard = card;
                        }
                            // se la bassa è un cavallo e la carta una donna metto la carta come nuova bassa
                        else if (card.Value < 3 && lowerCard.Value == 3)
                        {
                            lowerCard = card;
                        }
                            // se la carta è una donna,cavallo,re e la bassa è un asso o un 3 metto la carta nella bassa
                        else if (card.Value < 5 && lowerCard.Value > 5)
                        {
                            lowerCard = card;
                        }
                    }
                }
            }

            if (lowerCard != null)
            {
                return lowerCard;
            }
            // se bassa è nulla vuol dire che possiedo tutte briscole
            else
            {
                foreach (Card card in opponentCards)
                {
                    // se è la prima carta che scorro la metto come la più bassa temporanea
                    if (lowerCard == null)
                    {
                        lowerCard = card;
                    }
                        // se bassa possiede già una carta
                    else
                    {
                        // verifico se la carta è un liscio e se bassa ha un valore metto la carta come pià bassa
                        if (card.Value == 0 && lowerCard.Value > 0)
                        {
                            lowerCard = card;
                        }
                        // se la bassa è un asso metto come temporanea la carta corrente                           
                        else if (card.Value < 11 && lowerCard.Value == 11)
                        {
                            lowerCard = card;
                        }
                        // se la bassa è un 3 e la carta è più bassa la metto come nuova bassa
                        else if (card.Value < 10 && lowerCard.Value == 10)
                        {
                            lowerCard = card;
                        }
                        // se la bassa è un re e la carta è un cavallo metto la carta come nuova bassa
                        else if (card.Value < 4 && lowerCard.Value == 4)
                        {
                            lowerCard = card;
                        }
                        // se la bassa è un cavallo e la carta una donna metto la carta come nuova bassa
                        else if (card.Value < 3 && lowerCard.Value == 3)
                        {
                            lowerCard = card;
                        }
                        // se la carta è una donna,cavallo,re e la bassa è un asso o un 3 metto la carta nella bassa
                        else if (card.Value < 5 && lowerCard.Value > 5)
                        {
                            lowerCard = card;
                        }
                    }
                }

                return lowerCard;
            }
        }

        public static Card CheckThreeOfBriscola(List<Card> opponentCards, string briscola)
        {
            Card threeCard = null;

            foreach (Card card in opponentCards)
            {
                if (card.Seed == briscola && card.Number == 3)
                {
                    threeCard = card;
                }
                else
                {
                    threeCard = null;
                }
            }

            return threeCard;
        }
        
        public static Card CheckAceOfBriscola(List<Card> opponentCards, string briscola)
        {
            Card ace = null;

            foreach (Card card in opponentCards)
            {
                if (card.Seed == briscola && card.Number == 1)
                {
                    ace = card;
                }
            }

            return ace;
        }

        public static Card StartOpponentHand(List<Card> opponentCards, List<Card> previousHandCards, string briscola, int hand)
        {
            List<Card> opponentCopy = new List<Card>();
            opponentCopy.AddRange(opponentCards);

            if(hand == 17 || hand == 18 || hand == 19)
            {
                foreach (Card previousCard in previousHandCards)
                {
                    opponentCopy.Remove(previousCard);
                }

                Card card = StartOpponentHand(opponentCopy, briscola);

                return card;
            }
            else
            {
                return StartOpponentHand(opponentCards, briscola);
            }
        }

        public static Card StartOpponentHand(List<Card> opponentCards, string briscola)
        {
            // verifico quale sia la mia carta più bassa
            Card lowerCard = CheckLowerCard(opponentCards, briscola);

            // se la carta bassa è un carico
            if (lowerCard.Value >= 10)
            {
                // verifico se ho una briscola bassa
                Card lowerBriscola = CheckLowerBriscola(opponentCards, briscola);

                // se ho una briscola bassa la lancio
                if (lowerBriscola != null)
                {
                    return lowerBriscola;
                }
                // se non ho una briscola bassa
                else
                {
                    // se nelle carte ho sia l'asso e il tre di briscola ne lancio uno dei due
                    Card ace = CheckAceOfBriscola(opponentCards, briscola);
                    Card three = CheckThreeOfBriscola(opponentCards, briscola);

                    if (ace != null && three != null)
                    {
                        return three;
                    }
                    // se non possiedo tutti e due i carichi di briscola gioco la carta più bassa
                    else
                    {
                        return lowerCard;
                    }
                }
            }
            // se la carta non è un carico
            else
            {
                // lancio la carta più bassa
                return lowerCard;
            }

            
        }

        public static Card CalculateWinningCard(Card second, Card first, string briscola)
        {
            int opponentNumber = second.Number;
            int playerNumber = first.Number;
            bool opponentBriscola = (second.Seed == briscola);
            bool playerBriscola = (first.Seed == briscola);

            // se nessuna delle due carte è una briscola
            if (!opponentBriscola && !playerBriscola)
            {
                // se l'avversario ha un asso
                if (opponentNumber == 1)
                {
                    // verifico che le due carte sono dello stesso seme
                    if (second.Seed == first.Seed)
                    {
                        // nel caso siano dello stesso seme ritorno la carta dell'avversario poichè ha un asso
                        return second;
                    }
                    else
                    { //    QUESTO  NEL CASO IN CUI IL GIOCATORE TIRA PER PRIMO

                        // se non sono dello stesso seme e l'avversario ha un asso ritorno la carta 
                        // del giocatore
                        return first;
                    }
                }
                else if(opponentNumber==3)
                {
                    // verifico che le due carte sono dello stesso seme
                    if (second.Seed == first.Seed)
                    {
                        // se il giocatore non ha un asso dello stesso seme ritorno l'avversario
                        if (playerNumber != 1)
                        {
                            return second;
                        }
                        else
                        {
                            // se il giocatore ha un asso dello stesso seme ritorno il giocatore
                            return first;
                        }
                    }
                    else
                    {   //    QUESTO  NEL CASO IN CUI IL GIOCATORE TIRA PER PRIMO

                        //se non sono dello stesso seme ritorno il giocatore
                        return first;
                    }
                }
                else
                {
                    //nel caso in cui l'avversario non ha nè un asso nè un tre

                    // verifico che le due carte sono dello stesso seme
                    if (second.Seed == first.Seed)
                    {
                        // se il giocatore ha un asso o un tre dello stesso seme
                        if (playerNumber == 1 || playerNumber == 3)
                        {
                            // ritorno il giocatore poichè ha il carico dello stesso seme
                            return first;
                        }
                        else
                        {
                            // se il giocatore NON ha un asso o un tre dello stesso seme
                            if ((playerNumber - opponentNumber) > 0)
                            {
                                // se la carta del giocatore è un numero più alto dell'avversario
                                return first;
                            }
                            else
                            {
                                // se la carta del giocatore è un numero più piccolo dell'avversario
                                return second;
                            }
                        }
                    }
                    else
                    {   //    QUESTO  NEL CASO IN CUI IL GIOCATORE TIRA PER PRIMO

                        //se non sono dello stesso seme ritorno il giocatore
                        return first;
                    }
                }
            }
                // se l'avversario ha una briscola e il giocatore non ce l'ha
            else if(opponentBriscola && !playerBriscola)
            {
                return second;
            }
                // se il giocatore ha una briscola e l'avversario non ce l'ha
            else if (!opponentBriscola && playerBriscola)
            {
                return first;
            }
                //se tutti e due possiedono una briscola
            else
            {
                // se l'avversario ha un asso
                if (opponentNumber == 1)
                {
                    return second;
                }
                else if (opponentNumber == 3)
                {
                    // se l'avversario ha un tre
                    if (playerNumber != 1)
                    {
                        // se il giocatore non ha l'asso ritorno l'avversario
                        return second;
                    }
                    else
                    {
                        // se l'avversario ha un tre e il giocatore ha un asso ritorno il giocatore
                        return first;
                    }
                }
                else
                {
                    // se l'avversario non ha nè un asso nè un tre

                    //  verifico se il giocatore ha un asso o un tre dello stesso seme ritorno l'avversario
                    if (playerNumber == 1 || playerNumber == 3)
                    {
                        // ritorno il giocatore poichè ha il carico dello stesso seme
                        return first;
                    }
                    else
                    {
                        // se il giocatore non ha un asso o un tre dello stesso seme
                        if ((playerNumber - opponentNumber) > 0)
                        {
                            // se la carta del giocatore è un numero più alto dell'avversario
                            return first;
                        }
                        else
                        {
                            // se la carta del giocatore è un numero più piccolo dell'avversario
                            return second;
                        }
                    }
                }
            }
        }
    }
}
