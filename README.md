# Description
### THIS PROGRAM IS STILL A WORK IN PROGRESS 
This program simulates the Tarneeb card game, which is a trick-taking game played with a standard 52-card deck. The goal of the game is to be the first team to reach a certain number of points, which is determined by the winning score.

The game is played by four players in two teams of two, with each player being dealt 13 cards. The players then take turns playing a card from their hand, with the highest card of the leading suit (or the highest trump card if no cards of the leading suit are played) winning the trick. The team that wins the trick scores a point, and the player who played the highest card becomes the leader for the next trick.

At the start of the game, the players are asked to estimate the number of tricks they think they can win based on the cards in their hand. The player with the highest estimate gets to choose the Tarneeb suit, which is a suit that is ranked higher than the other suits in the game.

The game is played over 13 rounds, with each round consisting of four tricks. The team with the most points at the end of the 13 rounds wins the game.

## Classes
The program contains the following classes:

Card: Represents a playing card with a suit and rank.
Deck: Represents a deck of cards.
Player: Represents a player in the game, with a name, a hand of cards, a score, an estimate, and a team.
Game: Represents a game of Tarneeb, with a list of players, a deck of cards, a winning score, a current trick, a list of tricks, and scores for each team.

## Methods
The Game class contains the following methods:

StartGame(): Starts a new game of Tarneeb, including creating the players, dealing the cards, collecting estimates, and playing the tricks.
CollectEstimates(): Asks each player to calculate their estimate and determines the player with the highest estimate, who then gets to choose the Tarneeb suit.
DealCards(): Deals the cards to the players.
PlayTrick(int trickIndex): Plays a single trick of the game, including determining the winning player and team, updating the scores, and displaying the winning player and team.

## Running the Program
To run the program, compile and run the Game class. The program will prompt the players to select the Tarneeb suit, and then play the game until a winner is determined. The program will display the winning team at the end of the game.
