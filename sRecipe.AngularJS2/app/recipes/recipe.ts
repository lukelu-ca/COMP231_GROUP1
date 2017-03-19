export interface IRecipe {
    comments: any[],
    directions: any[],
    ingredients: {
        picture: any,
        id: number,
        recipeId: number,
        pictureId: number,
        name: string,
        unit: string,
        quantity: string
    }[],
    ratings: any[],
    user: {
        profile: {
            location: string,
            viewTheme: string,
            colorTheme: string
        },
        id: number,
        nickName: string,
        email: string,
        role: number
    },
    id: number,
    name: string,
    cooking_Time: number,
    number_of_Services: number,
    calorie: number,
    mealType: 
    {
        name: string
    },
    viewed: number,
    postTime: Date,
    isPublic: boolean,
    pictureId: number,
    userId: number
}
