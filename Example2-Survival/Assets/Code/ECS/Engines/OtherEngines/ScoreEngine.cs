namespace Svelto.ECS.Example.Survive.HUD
{
    public class ScoreEngine : IQueryingEntitiesEngine, IStep
    {
        public IEntitiesDB entitiesDB { get; set; }
        public void        Ready()    { }

        public void Step(EGID id)
        {
            var hudEntityViews =
                entitiesDB.QueryEntities<HUDEntityView>(ECSGroups.ExtraStuff, out var hudEntityViewsCount);

            if (hudEntityViewsCount > 0)
            {
                uint index;
                var  playerTargets = entitiesDB.QueryEntitiesAndIndex<ScoreValueEntityStruct>(id, out index);

                hudEntityViews[0].scoreComponent.score += playerTargets[index].scoreValue;
            }
        }
    }

    public struct ScoreValueEntityStruct : IEntityStruct
    {
        public int scoreValue;
    }
}