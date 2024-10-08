﻿using System.Collections.Generic;
using System.Threading;
using Entitas;

public class AReactiveSystem : ReactiveSystem<GameEntity>
{
    public AReactiveSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(GameMatcher.MyString);

    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> entities)
    {
        Thread.Sleep(2);
    }
}
