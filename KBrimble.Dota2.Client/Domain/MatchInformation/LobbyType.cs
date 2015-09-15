namespace KBrimble.Dota2.Client.Domain.MatchInformation
{
    public enum LobbyType
    {
        Invalid           = -1,
        PublicMatchmaking = 0,
        Practice          = 1,
        Tournament        = 2,
        Tutorial          = 3,
        CoOpWithBots      = 4,
        TeamMatch         = 5,
        SoloQueue         = 6,
        RebornPublicMatchmaking = 7,
        RebornPractice          = 8,
        RebornTournament        = 9,
        RebornTutorial          = 10,
        RebornCoOpWithBots      = 11,
        RebornTeamMatch         = 12,
        RebornSoloQueue         = 13
    }
}